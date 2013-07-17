using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cse.LocalShopping.ShopNearby.ModelBinders
{
	public class EnumToJsonModelBinder : DefaultModelBinder
	{
		protected override object GetPropertyValue(ControllerContext controllerContext, ModelBindingContext bindingContext,
	   PropertyDescriptor propertyDescriptor, IModelBinder propertyBinder)
		{
			var propertyType = propertyDescriptor.PropertyType;
			if (propertyType.IsEnum)
			{
				var providerValue = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
				if (null != providerValue)
				{
					var value = providerValue.RawValue;
					if (null != value)
					{
						var valueType = value.GetType();
						if (!valueType.IsEnum)
						{
							return Enum.ToObject(propertyType, value);
						}
					}
				}
			}
			return base.GetPropertyValue(controllerContext, bindingContext, propertyDescriptor, propertyBinder);
		}
	}
}