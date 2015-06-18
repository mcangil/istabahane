using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IsteBahane.Data;
using IsteBahane.Data.DB;
using IsteBahane.Manager;
using IsteBahane.Models;

namespace IsteBahane.Controllers
{
    public class ExcuseController : Controller
    {
        readonly IRepository<Excuse> _repository = new Repository<Excuse>();
        readonly IRepository<ExcuseShowLog> _showLogRepository = new Repository<ExcuseShowLog>();
        readonly CacheManager _cacheManager = new CacheManager();

        public ActionResult GetNewExcuse()
        {
            const string cacheKey = "excuse";
            var cacheResult = _cacheManager.Get<List<ExcuseModel>>(cacheKey);
            if (cacheResult != null)
            {
                var result = cacheResult.OrderBy(q => Guid.NewGuid()).FirstOrDefault();
                SetShowCount(result.Id);
                return Json(result, JsonRequestBehavior.AllowGet);
            }

            var entityList = _repository.GetAll(q => q.Status == 1);
            cacheResult = new List<ExcuseModel>();

            foreach (var item in entityList)
            {
                cacheResult.Add(new ExcuseModel
                {
                    Author = item.Author,
                    Description = item.Description,
                    DislikeCount = item.DislikeCount,
                    LikeCount = item.LikeCount,
                    ShowCount = item.ShowCount,
                    Id = item.Id
                });
            }

            _cacheManager.Add(cacheKey, cacheResult);
            var result1 = cacheResult.OrderBy(q => Guid.NewGuid()).FirstOrDefault();
            SetShowCount(result1.Id);
            return Json(result1, JsonRequestBehavior.AllowGet);
        }

        private void SetShowCount(int Id)
        {
            _repository.RunSql(string.Format("UPDATE Excuse SET showCount = ShowCount + 1 where Id = {0}", Id));
            _showLogRepository.Add(new ExcuseShowLog
            {
                Date = DateTime.Now,
                ExcuseId = Id,
                UserIp = Request.ServerVariables["REMOTE_ADDR"]
            });
        }

        [HttpPost]
        public ActionResult LikeOrDislike(int excuseId, string type)
        {
            switch (type)
            {
                case "Like":
                    _repository.RunSql(string.Format("UPDATE Excuse SET LikeCount = LikeCount + 1 where Id = {0}", excuseId));
                    break;
                case "Dislike":
                    _repository.RunSql(string.Format("UPDATE Excuse SET DislikeCount = DislikeCount + 1 where Id = {0}", excuseId));
                    break;
            }
            return Json("Ok");
        }

        [HttpPost]
        public ActionResult SaveNewExcuse(ExcuseModel model)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(new Excuse
                {
                    CreateDate = DateTime.Now,
                    Description = model.Description,
                    DislikeCount = model.DislikeCount,
                    ApproveDate = null,
                    Author = model.Author,
                    AuthorEmail = model.AuthorEmail,
                    LikeCount = model.LikeCount,
                    ShowCount = model.ShowCount,
                    Status = 0,

                });
            }
            return Json("Ok");
        }
    }
}