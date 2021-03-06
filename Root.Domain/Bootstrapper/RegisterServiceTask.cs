﻿using Hangerd.Bootstrapper;
using Hangerd.Event;
using Hangerd.Extensions;
using Microsoft.Practices.Unity;
using Root.Domain.Events;
using Root.Domain.Events.Handlers;

namespace Root.Domain.Bootstrapper
{
	public class RegisterServiceTask : RegisterServiceBootstrapperTask
	{
		public RegisterServiceTask(IUnityContainer container) : base(container)
		{
		}

		public override void Execute()
		{
			//domain services

			//domain events
			_container.RegisterMultipleTypesAsPerResolve<IDomainEventHandler<WordCreatedEvent>, WordCreatedEventHandler>();
		}
	}
}
