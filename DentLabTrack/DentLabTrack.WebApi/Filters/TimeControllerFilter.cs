﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DentLabTrack.WebApi.Filters
{
    public class TimeControllerFilter:ActionFilterAttribute
    {
       
    
        public string StartTime{ get; set; }
        public string EndTime { get; set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var now = DateTime.Now.TimeOfDay;
            StartTime = "23:00";
            EndTime = "23:59";
            if(now >= TimeSpan.Parse(StartTime) && now <= TimeSpan.Parse(EndTime))
            {
               base.OnActionExecuting(context);
            }
            else
            {
                context.Result = new ContentResult
                {
                    Content = "Bu saatler arasında bi end-pointe istek atılamaz",  
                    StatusCode = 403
                };
            }
        }
    }
}
