﻿using System.Web.Mvc;
using Machine.Specifications;

namespace MvcNavigation.Specifications.HtmlHelperExtensionSpecs
{
	[Subject(typeof(HtmlHelperExtensions))]
	public class when_link_for_parameterised_node_that_matches_current_path_is_requested : action_link_spec
	{
		static MvcHtmlString link;

		Because of = () =>
		{
			view_context.RouteData.Values.Add("controller", "Test");
			view_context.RouteData.Values.Add("action", "ParameterisedAction");

			route_collection.MapRoute("Test", "action", new { controller = "Test", action = "ParameterisedAction" });

			link = html_helper.ActionLink(new Node<TestController>(c => c.ParameterisedAction(1, "test")));
		};

		It should_generate_link_with_marker_css_class =
			() => link.ToString().ShouldEqual("<a class=\"selected\" href=\"/action?param1=1&amp;param2=test\">ParameterisedAction</a>");
	}
}