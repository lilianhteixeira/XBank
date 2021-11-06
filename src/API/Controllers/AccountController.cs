using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XBank.Domain.Core.Commands;
using XBank.Domain.Core.Entities;
using XBank.Domain.Core.Requests;
using XBank.Domain.Shared.Interfaces;

namespace XBank.Service.API.Controllers
{
    public class AccountController : ControllerBase
    {
        private readonly IQueryRepository<Account> _qRepository;
        private readonly ICommandRepository<Account> _cmdRepository;


        public AccountController(IQueryRepository<Account> qRepository, ICommandRepository<Account> cmdRepository)
        {
            _qRepository = qRepository;
            _cmdRepository = cmdRepository;
        }

        // POST: AccountController/Create
        [HttpPost]
        [Route("{id}")]
        public ActionResult Create([FromRoute] Guid id, [FromBody] AddMovementRequest request)
        {
            try
            {
                request.SetAccountId(id);

                var command = new AddMovementCommandHandler(_cmdRepository);

                var result = command.Handle(request);

                return Created("", result);
            }
            catch (Exception exc)
            {
                return BadRequest(new { messageError = exc.Message });
            }
        }
        //// GET: AccountController
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: AccountController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: AccountController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: AccountController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: AccountController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: AccountController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: AccountController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: AccountController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
