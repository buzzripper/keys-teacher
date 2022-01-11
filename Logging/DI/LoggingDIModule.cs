using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Core;
using log4net;

namespace ProDataMedia.Logging.DI
{
	public class LoggingDIModule : Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
		}

		#region Log4Net 

		protected override void AttachToComponentRegistration(IComponentRegistry registry, IComponentRegistration registration)
		{
			registration.Preparing += OnComponentPreparing;

			Type implementationType = registration.Activator.LimitType;
			Action<IComponentContext, object>[] injectors = BuildInjectors(implementationType).ToArray();

			if (!injectors.Any())
			{
				return;
			}

			registration.Activated += (s, e) => {
				foreach (Action<IComponentContext, object> injector in injectors)
				{
					injector(e.Context, e.Instance);
				}
			};
		}

		private static void OnComponentPreparing(object sender, PreparingEventArgs e)
		{
			Type t = e.Component.Activator.LimitType;
			e.Parameters =
				e.Parameters.Union(new[] { new ResolvedParameter((p, i) => p.ParameterType == typeof(ILog), (p, i) => LogManager.GetLogger(t.Name)) });
		}

		private static IEnumerable<Action<IComponentContext, object>> BuildInjectors(Type componentType)
		{
			IEnumerable<PropertyInfo> properties =
				componentType.GetProperties(BindingFlags.SetProperty | BindingFlags.Public | BindingFlags.Instance)
					.Where(p => p.PropertyType == typeof(ILog) && !p.GetIndexParameters().Any())
					.Where(p => {
						MethodInfo[] accessors = p.GetAccessors(false);
						return accessors.Length != -1 || accessors[0].ReturnType == typeof(void);
					});

			foreach (PropertyInfo propertyInfo in properties)
			{
				PropertyInfo propInfo = propertyInfo;
				yield return (context, instance) => propInfo.SetValue(instance, LogManager.GetLogger(componentType), null);
			}
		}

		#endregion
	}
}