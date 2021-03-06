﻿using System;
using System.Web.Mvc;
using Machine.Specifications;

namespace MvcNavigation.Specifications.HtmlHelperExtensionSpecs
{
	[Subject(typeof(HtmlHelperExtensions))]
	public class when_named_menu_is_requested_before_configuration
	{
		static Exception exception;

		Because of = () =>
		{
			NavigationConfiguration.Initialise("NamedSitemap", null);
			var htmlHelper = new HtmlHelper(new ViewContext(), new ViewPage());
			exception = Catch.Exception(() => htmlHelper.Menu("NamedSitemap"));
		};

		It should_throw_invalid_operation_exception =
			() => exception.GetType().ShouldEqual(typeof(InvalidOperationException));

		It should_throw_exception_with_descriptive_message =
			() => exception.Message.ShouldEqual("Sitemap \"NamedSitemap\" is not initialised.");
	}
}