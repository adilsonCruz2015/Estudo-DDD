

using ADC.Portal.Solution.Domain.Command.CategoryCmd;
using ADC.Portal.Solution.Domain.ObjectValue;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ADC.Portal.Solution.Test.Domain.Command
{
    [TestClass]
    public class FilterCmdTest
    {
        [TestMethod]
        public void FilterCmd_pass_params_Valid()
        {
            FilterCmd filterCmd = new FilterCmd();
            IEnumerable<Guid> guids = new List<Guid>() { Guid.NewGuid(),  Guid.NewGuid() };
            IEnumerable<Status> statuses = new List<Status>() { Status.Active, Status.Inactive };

            filterCmd.ConcatStatus(statuses);
            filterCmd.ConcatCategory(guids);

            Assert.IsTrue(filterCmd.IsValid());
        }

        [TestMethod]
        public void FilterCmd_no_pass_params_Valid()
        {
            FilterCmd filterCmd = new FilterCmd();
            Assert.IsTrue(filterCmd.IsValid());
        }
    }
}
