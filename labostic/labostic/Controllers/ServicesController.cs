using ClosedXML.Excel;
using labostic.ViewModels;
using Labostic.Models;
using Labostic.Services.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace labostic.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IServices _service;

        public ServicesController(IServices service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            ViewBag.Active = "Service";
            List<Services> services = _service.GetServiceses();

            List<VmBlogToExcel> data = services.Select(b => new VmBlogToExcel
            {
                Title = b.Title,
                Desc = b.Name,
                Icon = b.Name,
                TitleTwo = b.Name,
            }).ToList();

            TempData["BlogList"] = JsonConvert.SerializeObject(data);
            return View(services);
        }
        public IActionResult Two()
        {
            List<Services> services = _service.GetServiceses();

            return View(services);
        }
        public IActionResult Three()
        {
            List<Services> services = _service.GetServiceses();

            return View(services);
        }
        public IActionResult Four()
        {
            List<Services> services = _service.GetServiceses();

            return View(services);
        }
        public IActionResult Five()
        {
            List<Services> services = _service.GetServiceses();

            return View(services);
        }
        public IActionResult Six()
        {
            List<Services> services = _service.GetServiceses();

            return View(services);
        }

        public IActionResult ExportBlog()
        {
            string services = (string)TempData["BlogList"];
            List<VmBlogToExcel> data = JsonConvert.DeserializeObject<List<VmBlogToExcel>>(services);

            List<char> letters = new List<char>()
            {
                'A','B', 'C','D','E','F'
            };

            var workbook = new XLWorkbook();
            var ws = workbook.AddWorksheet("Blog list");

            ws.Row(1).Height = 4;
            ws.Row(2).Height = 30;
            ws.Row(3).Height = 22;

            ws.Column("A").Width = 0.3;
            ws.Column("B").Width = 8;
            ws.Column("C").Width = 50;
            ws.Column("D").Width = 30;
            ws.Column("E").Width = 25;
            ws.Column("F").Width = 20;

            ws.Range("B2:F2").Merge();
            ws.Cell("B2").Value = "Blog list";
            ws.Cell("B2").Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
            ws.Cell("B2").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            ws.Cell("B2").Style.Font.SetBold();
            ws.Cell("B2").Style.Font.FontSize = 14;

            for (int i = 0; i < (letters.Count - 1); i++)
            {
                ws.Cell(letters[i + 1] + "3").Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                ws.Cell(letters[i + 1] + "3").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                ws.Cell(letters[i + 1] + "3").Style.Font.SetBold();
                ws.Cell(letters[i + 1] + "3").Style.Font.FontSize = 14;
                ws.Cell(letters[i + 1] + "3").Style.Font.FontColor = XLColor.White;
                ws.Cell(letters[i + 1] + "3").Style.Fill.BackgroundColor = XLColor.Blue;
                ws.Cell(letters[i + 1] + "3").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                ws.Cell(letters[i + 1] + "3").Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Cell(letters[i + 1] + "3").Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                ws.Cell(letters[i + 1] + "3").Style.Border.RightBorder = XLBorderStyleValues.Thin;
            }
            ws.Cell("B3").Value = "#";
          

            ws.Cell("C3").Value = "Title";
           

            ws.Cell("D3").Value = "Desc";
           

            ws.Cell("E3").Value = "Icon";
           

            ws.Cell("F3").Value = "Title two";
          

            //int j = 4;
            for (int i = 0; i < data.Count; i++)
            {
                for (int j = 0; j < (letters.Count - 1); j++)
                {
                    ws.Cell("" + letters[j + 1] + (i + 4)).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                    ws.Cell("" + letters[j + 1] + (i + 4)).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    ws.Cell("" + letters[j + 1] + (i + 4)).Style.Font.FontSize = 12;
                    ws.Cell("" + letters[j + 1] + (i + 4)).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                    ws.Cell("" + letters[j + 1] + (i + 4)).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                    ws.Cell("" + letters[j + 1] + (i + 4)).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                    ws.Cell("" + letters[j + 1] + (i + 4)).Style.Border.RightBorder = XLBorderStyleValues.Thin;

                    if (letters[j + 1] == 'C')
                    {
                        ws.Cell("C" + (i + 4)).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);
                        ws.Cell("C" + (i + 4)).Style.Alignment.WrapText = true;
                    }
                }


                ws.Cell("B" + (i + 4)).Value = i + 1;
                ws.Cell("C" + (i + 4)).Value = data[i].Title;
                ws.Cell("D" + (i + 4)).Value = data[i].Desc;
                ws.Cell("E" + (i + 4)).Value = data[i].Icon;
                ws.Cell("F" + (i + 4)).Value = data[i].TitleTwo;
                    
            }

            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                var content = stream.ToArray();
                return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Blogs.xlsx");
            }
        }
    }
}
