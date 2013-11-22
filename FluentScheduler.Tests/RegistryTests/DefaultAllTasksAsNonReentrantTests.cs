﻿using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace FluentScheduler.Tests.RegistryTests
{
	[TestFixture]
	public class DefaultAllTasksAsNonReentrantTests
	{
		[Test]
		public void Should_Set_NonReentrant_For_Any_Previously_Configured_Task_In_The_Registry()
		{
			var registry = new RegistryWithPreviousTasksConfigured();
			foreach (var schedule in registry.Schedules)
			{
				Assert.IsFalse(schedule.Reentrant);
			}
		}
		private class RegistryWithPreviousTasksConfigured : Registry
		{
			public RegistryWithPreviousTasksConfigured()
			{
				Schedule(async() => Console.WriteLine("Hi"));
				Schedule<StronglyTypedTestTask>();
				DefaultAllTasksAsNonReentrant();
			}
		}

		[Test]
		public void Should_Set_Future_Configured_Tasks_In_The_Registry()
		{
			var registry = new RegistryWithFutureTasksConfigured();
			foreach (var schedule in registry.Schedules)
			{
				Assert.IsFalse(schedule.Reentrant);
			}
		}

		private class RegistryWithFutureTasksConfigured : Registry
		{
			public RegistryWithFutureTasksConfigured()
			{
				DefaultAllTasksAsNonReentrant();
				Schedule(async() => Console.WriteLine("Hi"));
				Schedule<StronglyTypedTestTask>();
			}
		}
		private abstract class StronglyTypedTestTask : ITask
		{
			public async Task Execute()
			{
				 Console.WriteLine("Hi");
			}
		}
	}
}
