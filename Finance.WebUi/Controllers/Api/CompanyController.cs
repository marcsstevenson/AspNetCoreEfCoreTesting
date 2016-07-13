using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Finance.Logic.Crm;
using Finance.Repository.EfCore.Models;
using Finance.WebUi.Services;
using Generic.Framework.Enumerations;
using Generic.Framework.Helpers;
using Generic.Framework.Interfaces.Entity;
using Generic.Framework.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Finance.WebUi.Controllers.Api
{
    //[Produces("application/json")]
    [Route("api/Company")]
    public class CompanyController : Controller
    {
        private IPersistanceFactory _persistanceFactory;

        public CompanyController(
            IPersistanceFactory persistanceFactory)
        {
            _persistanceFactory = persistanceFactory;

        }

        public IList<Customer> Get()
        {
            var repoCompany = _persistanceFactory.BuildEntityRepository<Customer>();

            CommitAction commitAction = CommitAction.None;

            IUnitOfWork UnitOfWork = _persistanceFactory.BuildUnitOfWork();
            Customer customer = null;

            var commitResult = UnitOfWork.Commit(() =>
            {
                customer = new Customer();
                
                commitAction = repoCompany.Save(customer);
            });

            //Add the result to the commit actions
            commitResult.CommitActions.Add(customer, commitAction);

            if (commitResult.HasError)
            {
                var error = commitResult.ErrorMessage;
            }

            var customers = repoCompany.AllList();

            return customers;
        }
    }
}