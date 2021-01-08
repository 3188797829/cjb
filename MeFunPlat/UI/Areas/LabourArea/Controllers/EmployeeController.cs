using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeFunModel;

namespace UI.Areas.LabourArea.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: LabourArea/Employee
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetData()
        {
            List<Announcer> anlist = new List<Announcer>();
            using (MyContext context = new MyContext())
            {
                anlist = context.Announcer.Where(x => x.State == 0).ToList();
            }
            var data = new
            {
                count = anlist.Count(),//数据总条数，用于分页
                code = 0,//code码是必须要的， 0 表述返回的数据没有问题
                data = anlist,//数据源
                msg = "人员信息"//描述
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult AddAnnouncer(Announcer info)
        {
            string result = "Fail";
            using(MyContext context=new MyContext())
            {
                context.Announcer.Add(info);
                int r = context.SaveChanges();
                if (r > 0)
                {
                    result = "Success";
                }               
            }
            return Content(result);
        }

    }
}