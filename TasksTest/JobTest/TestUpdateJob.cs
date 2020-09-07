﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TasksModels;
using TasksService.Instance;
using TasksService.Interface;

namespace TasksTest.JobTest
{
    [TestClass]
    public class TestUpdateJob
    {
        ITaskService service;

        [TestInitialize]
        public void StartUp()
        {
            service = new TaskService();
        }

        [TestMethod]
        public void testupdateJob_UpdateNameOfJob()
        {
            //Arrange
            service.addNewTask("Task 1");
            service.AddJob(1, "Job 1");

            //Act
            Task result = service.UpdateJobName(1, 1, "Job 2").First();

            //Assert
            Assert.AreEqual("Job 2", result.Jobs.First().Name);
        }

        [TestMethod]
        public void testupdateJob_UpdateStatusOfJob()
        {
            //Arrange
            service.addNewTask("Task 1");
            service.AddJob(1, "Job 1");

            //Act
            Task result = service.UpdateCheckJob(1, 1).First();

            //Assert
            Assert.IsTrue(result.Jobs.First().Done);

        }

        [TestCleanup]
        public void CleanUp()
        {
            service.DeleteAllTasks();
        }
    }
}