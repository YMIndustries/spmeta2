﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.Definitions;
using SPMeta2.Models;
using SPMeta2.Regression.Model.Definitions;
using SPMeta2.Regression.Tests.Base;
using SPMeta2.Regression.Tests.Common;
using SPMeta2.Syntax.Default;
using SPMeta2.Syntax.Default.Modern;
using SPMeta2.Regression.Common.Utils;
using System.Reflection;
using SPMeta2.Attributes;
using SPMeta2.Utils;
using SPMeta2.Attributes.Regression;

using SPMeta2.Syntax.Default.Extensions;
using SPMeta2.Enumerations;
using SPMeta2.Regression.Services;
using SPMeta2.Definitions.Fields;
using SPMeta2.Regression.Exceptions;
using System.IO;
using SPMeta2.Validation.Services;
using SPMeta2.Regression.Assertion;

namespace SPMeta2.Regression.Tests.Impl.Random
{
    [TestClass]
    public class RandomDefinitionTest : SPMeta2RegresionEventsTestBase
    {
        #region common

        [ClassInitializeAttribute]
        public static void Init(TestContext context)
        {
            InternalInit();

           

            //ReportService.OnReportItemAdded += OnReportItemAdded;
        }       

        [ClassCleanupAttribute]
        public static void Cleanup()
        {
            InternalCleanup();

            //var testReports = TestReports;

            //var testClassReport = new TestClassReport();

            //testClassReport.ClassName = typeof(RandomDefinitionTest).FullName;

            //var methods = typeof(RandomDefinitionTest).GetMethods();

            //foreach (var method in methods)
            //{
            //    var testReport = TestReports.FirstOrDefault(r => r.TestName == method.Name);

            //    if (testReport != null)
            //    {
            //        testClassReport.AddTestReportItem(testReport);
            //    }
            //}

            //var extraTypes = ReflectionUtils.GetTypesFromAssemblies<DefinitionBase>(
            //    new Assembly[] { typeof(FieldDefinition).Assembly });

            //var testReportXml = XmlSerializerUtils.SerializeToString(testClassReport, extraTypes);

            //Console.Write("");
        }

        //private static void OnReportItemAdded(object sender, OnTestReportNodeAddedEventArgs e)
        //{
        //    ReportNodes.Add(e.Node);

        //}

        [TestMethod]
        [TestCategory("Regression.Rnd")]
        public void SelfDiagnostic_TestShouldHaveAllDefinitions()
        {
            var methods = GetType().GetMethods();

            var spMetaAssembly = typeof(FieldDefinition).Assembly;
            var allDefinitions = ReflectionUtils.GetTypesFromAssembly<DefinitionBase>(spMetaAssembly);

            foreach (var def in allDefinitions)
            {
                Trace.WriteLine(def.Name);
            }

            foreach (var definition in allDefinitions)
            {
                var hasTestMethod = HasTestMethod("CanDeployRandom_", definition, methods);

                Assert.IsTrue(hasTestMethod);
            }
        }

        #endregion

        #region farm scope

        [TestMethod]
        [TestCategory("Regression.Rnd.Farm")]
        public void CanDeployRandom_FarmDefinition()
        {
            WithExcpectedCSOMnO365RunnerExceptions(() =>
            {
                TestRandomDefinition<FarmDefinition>();
            });
        }

        [TestMethod]
        [TestCategory("Regression.Rnd.Farm")]
        public void CanDeployRandom_ManagedAccountDefinition()
        {
            WithExcpectedCSOMnO365RunnerExceptions(() =>
            {
                TestRandomDefinition<ManagedAccountDefinition>();
            });
        }

        #endregion

        #region web app scope

        [TestMethod]
        [TestCategory("Regression.Rnd.WebApplication")]
        public void CanDeployRandom_WebApplicationDefinition()
        {
            WithExcpectedCSOMnO365RunnerExceptions(() =>
            {
                TestRandomDefinition<WebApplicationDefinition>();
            });
        }

        [TestMethod]
        [TestCategory("Regression.Rnd.WebApplication")]
        public void CanDeployRandom_JobDefinition()
        {
            WithExcpectedCSOMnO365RunnerExceptions(() =>
            {
                TestRandomDefinition<JobDefinition>();
            });
        }

        [TestMethod]
        [TestCategory("Regression.Rnd.WebApplication")]
        public void CanDeployRandom_PrefixDefinition()
        {
            WithExcpectedCSOMnO365RunnerExceptions(() =>
            {
                TestRandomDefinition<PrefixDefinition>();
            });
        }

        #endregion

        #region site scope

        [TestMethod]
        [TestCategory("Regression.Rnd.Site")]
        public void CanDeployRandom_SiteDefinition()
        {
            WithExcpectedCSOMnO365RunnerExceptions(() =>
            {
                TestRandomDefinition<SiteDefinition>();
            });
        }

        [TestMethod]
        [TestCategory("Regression.Rnd.Site")]
        public void CanDeployRandom_UserCustomActionDefinition()
        {
            TestRandomDefinition<UserCustomActionDefinition>();
        }

        [TestMethod]
        [TestCategory("Regression.Rnd.Site")]
        public void CanDeployRandom_FieldDefinition()
        {
            TestRandomDefinition<FieldDefinition>();
        }

        [TestMethod]
        [TestCategory("Regression.Rnd.Site")]
        public void CanDeployRandom_BusinessDataFieldDefinition()
        {
            TestRandomDefinition<BusinessDataFieldDefinition>();
        }

        [TestMethod]
        [TestCategory("Regression.Rnd.Site")]
        public void CanDeployRandom_SandboxSolutionDefinition()
        {
            TestRandomDefinition<SandboxSolutionDefinition>();
        }

        [TestMethod]
        [TestCategory("Regression.Rnd.Site")]
        public void CanDeployRandom_ContentTypeDefinition()
        {
            TestRandomDefinition<ContentTypeDefinition>();
        }

        [TestMethod]
        [TestCategory("Regression.Rnd.Site")]
        public void CanDeployRandom_ContentTypeFieldLinkDefinition()
        {
            TestRandomDefinition<ContentTypeFieldLinkDefinition>();
        }

        #endregion

        #region web scope

        [TestMethod]
        [TestCategory("Regression.Rnd.Web")]
        public void CanDeployRandom_WebDefinition()
        {
            TestRandomDefinition<WebDefinition>();
        }

        [TestMethod]
        [TestCategory("Regression.Rnd.Web")]
        public void CanDeployRandom_QuickLaunchNavigationNodeDefinition()
        {
            TestRandomDefinition<QuickLaunchNavigationNodeDefinition>();
        }

        [TestMethod]
        [TestCategory("Regression.Rnd.Web")]
        public void CanDeployRandom_SP2013WorkflowDefinition()
        {
            TestRandomDefinition<SP2013WorkflowDefinition>();
        }


        [TestMethod]
        [TestCategory("Regression.Rnd.Web")]
        public void CanDeployRandom_TopNavigationNodeDefinition()
        {
            TestRandomDefinition<TopNavigationNodeDefinition>();
        }

        [TestMethod]
        [TestCategory("Regression.Rnd.Web")]
        public void CanDeployRandom_PropertyDefinition()
        {
            TestRandomDefinition<PropertyDefinition>();
        }

        [TestMethod]
        [TestCategory("Regression.Rnd.Web")]
        public void CanDeployRandom_FeatureDefinition()
        {
            TestRandomDefinition<FeatureDefinition>();
        }

        [TestMethod]
        [TestCategory("Regression.Rnd.Web")]
        public void CanDeployRandom_ListDefinition()
        {
            TestRandomDefinition<ListDefinition>();
        }

        #endregion

        #region list scope

        [TestMethod]
        [TestCategory("Regression.Rnd.List")]
        public void CanDeployRandom_ListItemFieldValueDefinition()
        {
            TestRandomDefinition<ListItemFieldValueDefinition>();
        }

        [TestMethod]
        [TestCategory("Regression.Rnd.List")]
        public void CanDeployRandom_BreakRoleInheritanceDefinition()
        {
            TestRandomDefinition<BreakRoleInheritanceDefinition>();
        }

        [TestMethod]
        [TestCategory("Regression.Rnd.List")]
        public void CanDeployRandom_ContentTypeLinkDefinition()
        {
            TestRandomDefinition<ContentTypeLinkDefinition>();
        }

        [TestMethod]
        [TestCategory("Regression.Rnd.List")]
        public void CanDeployRandom_FolderDefinition()
        {
            TestRandomDefinition<FolderDefinition>();
        }

        [TestMethod]
        [TestCategory("Regression.Rnd.List")]
        public void CanDeployRandom_ListFieldLinkDefinition()
        {
            TestRandomDefinition<ListFieldLinkDefinition>();
        }

        [TestMethod]
        [TestCategory("Regression.Rnd.List")]
        public void CanDeployRandom_ModuleFileDefinition()
        {
            TestRandomDefinition<ModuleFileDefinition>();
        }

        [TestMethod]
        [TestCategory("Regression.Rnd.List")]
        public void CanDeployRandom_SP2013WorkflowSubscriptionDefinition()
        {
            TestRandomDefinition<SP2013WorkflowSubscriptionDefinition>();
        }

        [TestMethod]
        [TestCategory("Regression.Rnd.List")]
        public void CanDeployRandom_ListItemDefinition()
        {
            TestRandomDefinition<ListItemDefinition>();
        }

        [TestMethod]
        [TestCategory("Regression.Rnd.List")]
        public void CanDeployRandom_ListViewDefinition()
        {
            TestRandomDefinition<ListViewDefinition>();
        }

        #endregion

        #region pages scope

        [TestMethod]
        [TestCategory("Regression.Rnd.Pages")]
        public void CanDeployRandom_PublishingPageDefinition()
        {
            TestRandomDefinition<PublishingPageDefinition>();
        }

        [TestMethod]
        [TestCategory("Regression.Rnd.Pages")]
        public void CanDeployRandom_WebPartDefinition()
        {
            TestRandomDefinition<WebPartDefinition>();
        }

        [TestMethod]
        [TestCategory("Regression.Rnd.Pages")]
        public void CanDeployRandom_WebPartPageDefinition()
        {
            TestRandomDefinition<WebPartPageDefinition>();
        }

        [TestMethod]
        [TestCategory("Regression.Rnd.Pages")]
        public void CanDeployRandom_WikiPageDefinition()
        {
            TestRandomDefinition<WikiPageDefinition>();
        }

        #endregion

        #region security scope

        [TestMethod]
        [TestCategory("Regression.Rnd.Security")]
        public void CanDeployRandom_SecurityGroupDefinition()
        {
            TestRandomDefinition<SecurityGroupDefinition>();
        }

        [TestMethod]
        [TestCategory("Regression.Rnd.Security")]
        public void CanDeployRandom_SecurityGroupLinkDefinition()
        {
            TestRandomDefinition<SecurityGroupLinkDefinition>();
        }


        [TestMethod]
        [TestCategory("Regression.Rnd.Security")]
        public void CanDeployRandom_SecurityRoleDefinition()
        {
            TestRandomDefinition<SecurityRoleDefinition>();
        }

        [TestMethod]
        [TestCategory("Regression.Rnd.Security")]
        public void CanDeployRandom_SecurityRoleLinkDefinition()
        {
            TestRandomDefinition<SecurityRoleLinkDefinition>();
        }

        #endregion


    }
}