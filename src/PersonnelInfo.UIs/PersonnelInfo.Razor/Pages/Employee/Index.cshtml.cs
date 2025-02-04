using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonnelInfo.Core.DTOs.Employees;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace PersonnelInfo.Razor.Pages.Employee
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public IndexModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public EmployeeDto Employee { get; set; }
        public List<EmployeeDto> Employees { get; set; }
        public List<string> Headers { get; set; } 
        public async Task OnGet()
        {
            Headers=GetHeaders(typeof(EmployeeDto));
            var client = _httpClientFactory.CreateClient("API");
            var response = await client.GetAsync("api/Employee/GetAll");

            if (response.IsSuccessStatusCode)
            {
                Employees = await response.Content.ReadFromJsonAsync<List<EmployeeDto>>();
            }
            Employees = new();
        }

        private List<string> GetHeaders(Type entity)
        {
            return entity.GetProperties().Select(prop=>
            {
                var displayAttr = prop.GetCustomAttribute<DisplayAttribute>();
                return displayAttr != null ? displayAttr.Name : prop.Name;
            }).ToList()?? throw new Exception($"{entity.Name} has no properties");

        }
    }
}

