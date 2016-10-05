using System;
using System.Collections.Generic;
using Ninject;
using Sis.Interview.Dal.Framework;
using Sis.Interview.Dal.Services;
using Sis.Interview.Models.ScrumCeremony;

namespace Sis.Interview.Tests
{
    public abstract class BaseTest
    {
        private readonly IKernel _kernel;

        protected BaseTest()
        {
            _kernel = new StandardKernel();
            _kernel.Bind(typeof(IRepository<>)).To(typeof(Repository<>));
            _kernel.Bind<BaseService<Retrospective>>().To<RetrospectiveService>();
        }

        protected TService GetService<TService>()
        {
            return _kernel.Get<TService>();
        }

        protected virtual Retrospective CreateTestRetrospective()
        {
            return new Retrospective
            {
                Name = Guid.NewGuid().ToString(),
                Date = DateTime.Now,
                Participants = new List<string> { "Viktor", "Gareth", "Mike" }
            };
        }
    }
}
