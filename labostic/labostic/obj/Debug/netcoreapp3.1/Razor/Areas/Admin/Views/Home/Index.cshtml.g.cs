#pragma checksum "C:\Users\User\OneDrive\Masaüstü\New folder (2)\labostic\labostic\Areas\Admin\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f0ff95c8168ec83902c38f9dc357705b6eca598d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Home_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Home/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\User\OneDrive\Masaüstü\New folder (2)\labostic\labostic\Areas\Admin\Views\_ViewImports.cshtml"
using labostic;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\OneDrive\Masaüstü\New folder (2)\labostic\labostic\Areas\Admin\Views\_ViewImports.cshtml"
using labostic.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\User\OneDrive\Masaüstü\New folder (2)\labostic\labostic\Areas\Admin\Views\_ViewImports.cshtml"
using labostic.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f0ff95c8168ec83902c38f9dc357705b6eca598d", @"/Areas/Admin/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ff5494e5fb4beda5b0666f20b22933f63aa8a93a", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Labostic.Models.Check>
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\User\OneDrive\Masaüstü\New folder (2)\labostic\labostic\Areas\Admin\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n\r\n<!-- Mirrored from emr.dreamguystech.com/html/index.html by HTTrack Website Copier/3.x [XR&CO\'2014], Fri, 27 Aug 2021 09:15:06 GMT -->\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f0ff95c8168ec83902c38f9dc357705b6eca598d3822", async() => {
                WriteLiteral(@"

    <div class=""main-wrapper"">





        <div class=""page-wrapper"">
            <div class=""content container-fluid"">
                <div class=""row"">
                    <div class=""col-12 col-md-6 col-lg-3 d-flex flex-wrap"">
                        <div class=""card detail-box1 details-box"">
                            <div class=""card-body"">
                                <div class=""dash-contetnt"">
                                    <div class=""mb-3"">
                                        <img src=""assets/img/icons/accident.svg""");
                BeginWriteAttribute("alt", " alt=\"", 815, "\"", 821, 0);
                EndWriteAttribute();
                WriteLiteral(" width=\"26\">\r\n                                    </div>\r\n                                    <h4 class=\"text-white\">Total Patients Analysis</h4>\r\n\r\n                                    <h2 class=\"text-white\">");
#nullable restore
#line 30 "C:\Users\User\OneDrive\Masaüstü\New folder (2)\labostic\labostic\Areas\Admin\Views\Home\Index.cshtml"
                                                      Write(Model.FinCode.Count());

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</h2>
                                    <div class=""growth-indicator"">
                                        <span class=""text-white""><i class=""fas fa-angle-double-up mr-1""></i> (14.25%)</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class=""col-12 col-md-6 col-lg-3 d-flex flex-wrap"">
                        <div class=""card detail-box2 details-box"">
                            <div class=""card-body"">
                                <div class=""dash-contetnt"">
                                    <div class=""mb-3"">
                                        <img src=""assets/img/icons/visits.svg""");
                BeginWriteAttribute("alt", " alt=\"", 1826, "\"", 1832, 0);
                EndWriteAttribute();
                WriteLiteral(@" width=""26"">
                                    </div>
                                    <h4 class=""text-white"">Patients Visit</h4>
                                    <h2 class=""text-white"">137</h2>
                                    <div class=""growth-indicator"">
                                        <span class=""text-white""><i class=""fas fa-angle-double-down mr-1""></i> (4.78%)</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class=""col-12 col-md-6 col-lg-3 d-flex flex-wrap"">
                        <div class=""card detail-box3 details-box"">
                            <div class=""card-body"">
                                <div class=""dash-contetnt"">
                                    <div class=""mb-3"">
                                        <img src=""assets/img/icons/hospital-bed.svg""");
                BeginWriteAttribute("alt", " alt=\"", 2814, "\"", 2820, 0);
                EndWriteAttribute();
                WriteLiteral(@" width=""26"">
                                    </div>
                                    <h4 class=""text-white"">New Admit</h4>
                                    <h2 class=""text-white"">24</h2>
                                    <div class=""growth-indicator"">
                                        <span class=""text-white""><i class=""fas fa-angle-double-up mr-1""></i> (18.32%)</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class=""col-12 col-md-6 col-lg-3 d-flex flex-wrap"">
                        <div class=""card detail-box4 details-box"">
                            <div class=""card-body"">
                                <div class=""dash-contetnt"">
                                    <div class=""mb-3"">
                                        <img src=""assets/img/icons/operating.svg""");
                BeginWriteAttribute("alt", " alt=\"", 3792, "\"", 3798, 0);
                EndWriteAttribute();
                WriteLiteral(@" width=""26"">
                                    </div>
                                    <h4 class=""text-white"">Operations</h4>
                                    <h2 class=""text-white"">05</h2>
                                    <div class=""growth-indicator"">
                                        <span class=""text-white""><i class=""fas fa-angle-double-down mr-1""></i> (25.14%)</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class=""row calender-col"">
                    <div class=""col-xl-4"">
                        <div class=""card"">
                            <div class=""card-header"">
                                <h4 class=""card-title"">Schedule</h4>
                            </div>
                            <div class=""card-body"">
                                <div id=""calendar-doctor"" class=""calenda");
                WriteLiteral(@"r-container""></div>
                            </div>
                        </div>
                    </div>
                    <div class=""col-xl-8 d-flex"">
                        <div class=""card flex-fill"">
                            <div class=""card-header"">
                                <div class=""d-flex justify-content-between align-items-center"">
                                    <h5 class=""card-title"">Patients Profile</h5>
                                    <div class=""dropdown"" data-toggle=""dropdown"">
                                        <a href=""javascript:void(0);"" class=""btn btn-white btn-sm dropdown-toggle"" role=""button"" data-toggle=""dropdown"">
                                            This Week
                                        </a>
                                        <div class=""dropdown-menu dropdown-menu-right"">
                                            <a href=""javascript:void(0);"" class=""dropdown-item"">Today</a>
                                  ");
                WriteLiteral(@"          <a href=""javascript:void(0);"" class=""dropdown-item"">This Week</a>
                                            <a href=""javascript:void(0);"" class=""dropdown-item"">This Month</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class=""card-body"">
                                <div class=""d-flex align-items-center justify-content-between flex-wrap flex-md-nowrap"">
                                    <div class=""w-100 d-md-flex align-items-center mb-3 chart-count"">
                                        <div class=""mr-3 text-center"">
                                            <span>Total Appointments</span>
                                            <p class=""h4 text-primary"">584</p>
                                        </div>
                                        <div class=""mr-3 text-center"">
                                        ");
                WriteLiteral(@"    <span>Old Patients</span>
                                            <p class=""h4 text-success"">320</p>
                                        </div>
                                        <div class=""mr-3 text-center"">
                                            <span>New Patients</span>
                                            <p class=""h4 text-warning"">264</p>
                                        </div>
                                    </div>
                                </div>
                                <div id=""dsh_chart_ex_column""></div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class=""row calender-col"">
                    <div class=""col-xl-8"">
                        <div class=""card"">
                            <div class=""card-header no-border"">
                                <h4 class=""card-title"">Medicine Requests</h4>
                            </div>
    ");
                WriteLiteral(@"                        <div class=""card-body"">
                                <div class=""table-responsive"">
                                    <table class=""table mb-0"">
                                        <thead>
                                            <tr>
                                                <th>Medicine</th>
                                                <th>Count</th>
                                                <th>Priority</th>
                                                <th>Time</th>
                                                <th>Status</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>Desmopressin tabs`</td>
                                                <td>200 strips</td>
                                                <td><span class=""badge bg-wa");
                WriteLiteral(@"rning-light"">Urgent</span></td>
                                                <td>10 mins ago</td>
                                                <td class=""text-warning"">Pending Approval</td>
                                            </tr>
                                            <tr>
                                                <td>Abciximab-injection</td>
                                                <td>50 nos</td>
                                                <td><span class=""badge bg-info-light"">Next Week</span></td>
                                                <td>5 days ago</td>
                                                <td class=""text-success"">On Time</td>
                                            </tr>
                                            <tr>
                                                <td>Paliperidone palmitate</td>
                                                <td>75 Strips</td>
                                                <td><span class=""b");
                WriteLiteral(@"adge bg-info-light"">Next Week</span></td>
                                                <td>1 Day Ago</td>
                                                <td class=""text-danger"">Delay</td>
                                            </tr>
                                            <tr>
                                                <td>Sermorelin-injectable</td>
                                                <td>22 nos</td>
                                                <td><span class=""badge bg-warning-light"">Urgent</span></td>
                                                <td>8 mins ago</td>
                                                <td class=""text-warning"">Pending Approval</td>
                                            </tr>
                                            <tr>
                                                <td>Abciximab-injection</td>
                                                <td>10 nos</td>
                                                <td><span class=""");
                WriteLiteral(@"badge bg-info-light"">Next Week</span></td>
                                                <td>2 days ago</td>
                                                <td class=""text-danger"">Delay</td>
                                            </tr>
                                            <tr>
                                                <td>Kevzara sarilumab</td>
                                                <td>35 Strips</td>
                                                <td><span class=""badge bg-warning-light"">Urgent</span></td>
                                                <td>5 mins ago</td>
                                                <td class=""text-warning"">Pending Approval</td>
                                            </tr>
                                            <tr>
                                                <td>Desmopressin</td>
                                                <td>155 Strips</td>
                                                <td><span class=""ba");
                WriteLiteral(@"dge bg-info-light"">Next Week</span></td>
                                                <td>1 days ago</td>
                                                <td class=""text-success"">On Time</td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class=""col-xl-4"">
                        <div class=""card"">
                            <div class=""card-header"">
                                <h4 class=""card-title"">Reviews Score</h4>
                            </div>
                            <div class=""card-body"">
                                <div id=""dsh_chart_ex_pie""></div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class=""card"">
             ");
                WriteLiteral(@"       <div class=""card-header no-border"">
                        <h4 class=""card-title float-left"">Upcoming Appointments</h4>
                        <span class=""float-right""><a href=""appointments.html"">View all</a></span>
                    </div>
                    <div class=""card-body"">
                        <div class=""table-responsive"">
                            <table class=""table mb-0"">
                                <thead>
                                    <tr>
                                        <th>ID</th>
                                        <th>Patient Name</th>
                                        <th>Age</th>
                                        <th>Date</th>
                                        <th>Time</th>
                                        <th>Disease</th>
                                        <th>Status</th>
                                        <th class=""text-right"">Action</th>
                                    </tr>
             ");
                WriteLiteral(@"                   </thead>
                                <tbody>
                                    <tr>
                                        <td>APT0001</td>
                                        <td><a href=""patients-profile.html""><img width=""28"" height=""28"" src=""assets/img/profiles/avatar-03.jpg"" class=""rounded-circle m-r-5""");
                BeginWriteAttribute("alt", " alt=\"", 14381, "\"", 14387, 0);
                EndWriteAttribute();
                WriteLiteral(@"> Maurice Guz</a></td>
                                        <td>39</td>
                                        <td>11 Dec 2020</td>
                                        <td>10:00am-12:00am</td>
                                        <td>Cold</td>
                                        <td class=""text-success"">Approved</td>
                                        <td class=""text-right"">
                                            <a href=""#"" class=""btn btn-sm btn-white text-success mr-2""><i class=""far fa-edit mr-1""></i> Edit</a>
                                            <a href=""javascript:void(0);"" class=""btn btn-sm btn-white text-danger mr-2""><i class=""far fa-trash-alt mr-1""></i>Delete</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>APT0002</td>
                                        <td><a href=""patients-profile.html""><img width=""28"" height=""28"" src=""asset");
                WriteLiteral("s/img/profiles/avatar-07.jpg\" class=\"rounded-circle m-r-5\"");
                BeginWriteAttribute("alt", " alt=\"", 15470, "\"", 15476, 0);
                EndWriteAttribute();
                WriteLiteral(@"> Brandon Stone</a></td>
                                        <td>29</td>
                                        <td>5 Dec 2020</td>
                                        <td>10:00am-12:00am</td>
                                        <td>Fever</td>
                                        <td class=""text-danger"">Canceled</td>
                                        <td class=""text-right"">
                                            <a href=""#"" class=""btn btn-sm btn-white text-success mr-2""><i class=""far fa-edit mr-1""></i> Edit</a>
                                            <a href=""javascript:void(0);"" class=""btn btn-sm btn-white text-danger mr-2""><i class=""far fa-trash-alt mr-1""></i>Delete</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>APT0003</td>
                                        <td><a href=""patients-profile.html""><img width=""28"" height=""28"" src=""asse");
                WriteLiteral("ts/img/profiles/avatar-06.jpg\" class=\"rounded-circle m-r-5\"");
                BeginWriteAttribute("alt", " alt=\"", 16560, "\"", 16566, 0);
                EndWriteAttribute();
                WriteLiteral(@"> Terry Baker</a></td>
                                        <td>42</td>
                                        <td>6 Jan 2020</td>
                                        <td>10:00am-12:00am</td>
                                        <td>heart</td>
                                        <td class=""text-success"">Approved</td>
                                        <td class=""text-right"">
                                            <a href=""#"" class=""btn btn-sm btn-white text-success mr-2""><i class=""far fa-edit mr-1""></i> Edit</a>
                                            <a href=""javascript:void(0);"" class=""btn btn-sm btn-white text-danger mr-2""><i class=""far fa-trash-alt mr-1""></i>Delete</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>APT0004</td>
                                        <td><a href=""patients-profile.html""><img width=""28"" height=""28"" src=""asset");
                WriteLiteral("s/img/profiles/avatar-04.jpg\" class=\"rounded-circle m-r-5\"");
                BeginWriteAttribute("alt", " alt=\"", 17649, "\"", 17655, 0);
                EndWriteAttribute();
                WriteLiteral(@"> Kyle Woodbury</a></td>
                                        <td>23</td>
                                        <td>19 Dec 2020</td>
                                        <td>10:00am-12:00am</td>
                                        <td>Diabeties</td>
                                        <td class=""text-success"">Approved</td>
                                        <td class=""text-right"">
                                            <a href=""#"" class=""btn btn-sm btn-white text-success mr-2""><i class=""far fa-edit mr-1""></i> Edit</a>
                                            <a href=""javascript:void(0);"" class=""btn btn-sm btn-white text-danger mr-2""><i class=""far fa-trash-alt mr-1""></i>Delete</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>APT0005</td>
                                        <td><a href=""patients-profile.html""><img width=""28"" height=""28"" src");
                WriteLiteral("=\"assets/img/profiles/avatar-05.jpg\" class=\"rounded-circle m-r-5\"");
                BeginWriteAttribute("alt", " alt=\"", 18745, "\"", 18751, 0);
                EndWriteAttribute();
                WriteLiteral(@"> Marie Gallardo</a></td>
                                        <td>55</td>
                                        <td>15 Dec 2020</td>
                                        <td>10:00am-12:00am</td>
                                        <td>Cold</td>
                                        <td class=""text-success"">Approved</td>
                                        <td class=""text-right"">
                                            <a href=""#"" class=""btn btn-sm btn-white text-success mr-2""><i class=""far fa-edit mr-1""></i> Edit</a>
                                            <a href=""javascript:void(0);"" class=""btn btn-sm btn-white text-danger mr-2""><i class=""far fa-trash-alt mr-1""></i>Delete</a>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
                <div class=""row"">
            ");
                WriteLiteral(@"        <div class=""col-xl-4 d-flex flex-wrap"">
                        <div class=""card"">
                            <div class=""card-header no-border"">
                                <h4 class=""card-title float-left"">Recent Visits</h4>
                            </div>
                            <div class=""card-body"">
                                <div class=""table-responsive"">
                                    <table class=""table mb-0"">
                                        <thead>
                                            <tr>
                                                <th>Patients</th>
                                                <th class=""text-right pt-0"">Reports</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td><a href=""patients-profile.html""><img width=""28"" height=");
                WriteLiteral("\"28\" src=\"assets/img/profiles/avatar-03.jpg\" class=\"rounded-circle m-r-5\"");
                BeginWriteAttribute("alt", " alt=\"", 20873, "\"", 20879, 0);
                EndWriteAttribute();
                WriteLiteral(@"> Maurice Guz</a></td>
                                                <td class=""text-right"">
                                                    <a href=""patients-profile.html"" class=""btn btn-sm btn-white text-success""><i class=""far fa-eye mr-1""></i> View</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><a href=""patients-profile.html""><img width=""28"" height=""28"" src=""assets/img/profiles/avatar-05.jpg"" class=""rounded-circle m-r-5""");
                BeginWriteAttribute("alt", " alt=\"", 21481, "\"", 21487, 0);
                EndWriteAttribute();
                WriteLiteral(@"> Marie Gallardo</a></td>
                                                <td class=""text-right"">
                                                    <a href=""patients-profile.html"" class=""btn btn-sm btn-white text-success""><i class=""far fa-eye mr-1""></i> View</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><a href=""patients-profile.html""><img width=""28"" height=""28"" src=""assets/img/profiles/avatar-04.jpg"" class=""rounded-circle m-r-5""");
                BeginWriteAttribute("alt", " alt=\"", 22092, "\"", 22098, 0);
                EndWriteAttribute();
                WriteLiteral(@"> Kyle Woodbury</a></td>
                                                <td class=""text-right"">
                                                    <a href=""patients-profile.html"" class=""btn btn-sm btn-white text-success""><i class=""far fa-eye mr-1""></i> View</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><a href=""patients-profile.html""><img width=""28"" height=""28"" src=""assets/img/profiles/avatar-06.jpg"" class=""rounded-circle m-r-5""");
                BeginWriteAttribute("alt", " alt=\"", 22702, "\"", 22708, 0);
                EndWriteAttribute();
                WriteLiteral(@"> Terry Baker</a></td>
                                                <td class=""text-right"">
                                                    <a href=""patients-profile.html"" class=""btn btn-sm btn-white text-success""><i class=""far fa-eye mr-1""></i> View</a>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class=""col-xl-4 d-flex flex-wrap"">
                        <div class=""card"">
                            <div class=""card-header no-border"">
                                <h4 class=""card-title float-left"">Patients Group</h4>
                            </div>
                            <div class=""card-body"">
                                <div class=""table-responsive"">
           ");
                WriteLiteral(@"                         <table class=""table mb-0"">
                                        <thead>
                                            <tr>
                                                <th>Issues</th>
                                                <th class=""text-right pt-0"">Count</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>Cholesterol</td>
                                                <td class=""text-right text-fade"">5 Patients</td>
                                            </tr>
                                            <tr>
                                                <td>Diabetic</td>
                                                <td class=""text-right text-fade"">14 Patients</td>
                                            </tr>
                                 ");
                WriteLiteral(@"           <tr>
                                                <td>Blood Pressure</td>
                                                <td class=""text-right text-fade"">10 Patients</td>
                                            </tr>
                                            <tr>
                                                <td>Hypertension</td>
                                                <td class=""text-right text-fade"">21 Patients</td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class=""col-xl-4 d-flex flex-wrap"">
                        <div class=""card"">
                            <div class=""card-header no-border"">
                                <h4 class=""card-title float-left"">Doctors</h4>
                               ");
                WriteLiteral(@" <span class=""float-right""><a href=""appointments.html"">View all</a></span>
                            </div>
                            <div class=""card-body"">
                                <div class=""table-responsive"">
                                    <table class=""table mb-0"">
                                        <thead>
                                            <tr>
                                                <th>Doctor</th>
                                                <th class=""text-right pt-0"">Availabilty</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td><img src=""assets/img/profiles/avatar-14.jpg"" class=""rounded-circle m-r-5 profile-img""");
                BeginWriteAttribute("alt", " alt=\"", 26669, "\"", 26675, 0);
                EndWriteAttribute();
                WriteLiteral(@">Dr.Jay Soni</td>
                                                <td class=""text-success text-right"">Available</td>
                                            </tr>
                                            <tr>
                                                <td><img src=""assets/img/profiles/avatar-17.jpg"" class=""rounded-circle m-r-5 profile-img""");
                BeginWriteAttribute("alt", " alt=\"", 27033, "\"", 27039, 0);
                EndWriteAttribute();
                WriteLiteral(@">Dr.Sarah Smith</td>
                                                <td class=""text-danger text-right"">Absent</td>
                                            </tr>
                                            <tr>
                                                <td><img src=""assets/img/profiles/avatar-18.jpg"" class=""rounded-circle m-r-5 profile-img""");
                BeginWriteAttribute("alt", " alt=\"", 27396, "\"", 27402, 0);
                EndWriteAttribute();
                WriteLiteral(@"> Dr.John Deo</td>
                                                <td class=""text-success text-right"">Available</td>
                                            </tr>
                                            <tr>
                                                <td><img src=""assets/img/profiles/avatar-13.jpg"" class=""rounded-circle m-r-5 profile-img""");
                BeginWriteAttribute("alt", " alt=\"", 27761, "\"", 27767, 0);
                EndWriteAttribute();
                WriteLiteral(@">Dr.Kirsten Deleon</td>
                                                <td class=""text-success text-right"">Available</td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>



    </div>


   
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<!-- Mirrored from emr.dreamguystech.com/html/index.html by HTTrack Website Copier/3.x [XR&CO\'2014], Fri, 27 Aug 2021 09:15:30 GMT -->\r\n</html>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Labostic.Models.Check> Html { get; private set; }
    }
}
#pragma warning restore 1591
