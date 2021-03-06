﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Homework.Controllers.ActionResults;
using MVC_Homework.Models;
using MVC_Homework.Models.ViewModels;
using X.PagedList;

namespace MVC_Homework.Controllers
{
    [Authorize(Roles = "Admin,Customer")]
    public class 客戶銀行資訊Controller : BaseController //Controller
    {
        private readonly I客戶銀行資訊Repository blankRepository;
        private readonly I客戶資料Repository customeRepository;

        //public 客戶銀行資訊Controller()
        //{
        //    var unitOfWord = RepositoryHelper.GetUnitOfWork();
        //    blankRepository = RepositoryHelper.Get客戶銀行資訊Repository(unitOfWord);
        //    customeRepository = RepositoryHelper.Get客戶資料Repository(unitOfWord);
        //}

        public 客戶銀行資訊Controller(I客戶銀行資訊Repository blankRepository, I客戶資料Repository customeRepository)
        {
            this.blankRepository = blankRepository;
            this.customeRepository = customeRepository;
        }

        // GET: 客戶銀行資訊
        public ActionResult Index(QueryOption query)
        {
            var 客戶銀行資訊 = blankRepository.Search(query.Keyword)
                .OrderBy(query.GetSortString())
                .ToPagedList(query.Page, query.GetPageSize());

            ViewBag.QueryOption = query;

            return View(客戶銀行資訊);
        }

        public ActionResult ExcelExport()
        {
            return this.ExcelFile(blankRepository.All().ToArray());
        }

        // GET: 客戶銀行資訊/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶銀行資訊 客戶銀行資訊 = blankRepository.Find(id);
            if (客戶銀行資訊 == null)
            {
                return HttpNotFound();
            }
            return View(客戶銀行資訊);
        }

        // GET: 客戶銀行資訊/Create
        public ActionResult Create()
        {
            ViewBag.客戶Id = new SelectList(customeRepository.All(), "Id", "客戶名稱");
            return View();
        }

        // POST: 客戶銀行資訊/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶Id,銀行名稱,銀行代碼,分行代碼,帳戶名稱,帳戶號碼")] 客戶銀行資訊 客戶銀行資訊)
        {
            if (ModelState.IsValid)
            {
                blankRepository.Add(客戶銀行資訊);
                blankRepository.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.客戶Id = new SelectList(customeRepository.All(), "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            return View(客戶銀行資訊);
        }

        // GET: 客戶銀行資訊/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶銀行資訊 客戶銀行資訊 = blankRepository.Find(id);
            if (客戶銀行資訊 == null)
            {
                return HttpNotFound();
            }
            ViewBag.客戶Id = new SelectList(customeRepository.All(), "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            return View(客戶銀行資訊);
        }

        // POST: 客戶銀行資訊/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FormCollection form)
        {
            var blank = blankRepository.Find(id);
            if (blank == null)
                return HttpNotFound();

            if (TryUpdateModel(blank))
            {
                blankRepository.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.客戶Id = new SelectList(customeRepository.All(), "Id", "客戶名稱", blank.客戶Id);
            return View(blank);
        }

        // GET: 客戶銀行資訊/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶銀行資訊 客戶銀行資訊 = blankRepository.Find(id);
            if (客戶銀行資訊 == null)
            {
                return HttpNotFound();
            }
            return View(客戶銀行資訊);
        }

        // POST: 客戶銀行資訊/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            客戶銀行資訊 客戶銀行資訊 = blankRepository.Find(id);
            blankRepository.Delete(客戶銀行資訊);
            blankRepository.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                blankRepository.UnitOfWork.Context.Dispose();
                customeRepository.UnitOfWork.Context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
