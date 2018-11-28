﻿using System;
using Gadi.Business.Interfaces;
using Newtonsoft.Json;
using RazorEngine;
using RazorEngine.Configuration;
using RazorEngine.Templating;


namespace Gadi.Business.Services
{
    public class RazorService : IRazorService
    {
        private IRazorEngineService _service;

        public RazorService()
        {
            var config = new TemplateServiceConfiguration
            {
                BaseTemplateType = typeof(MvcTemplateBase<>),
                CachingProvider = new DefaultCachingProvider()
            };

            _service = RazorEngineService.Create(config);
            Engine.Razor = _service;
        }

        public void CacheTemplate(string templateName, string template)
        {
            try
            {
                Engine.Razor.Compile(template, templateName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool IsTemplateCached(string templateName)
        {
            return Engine.Razor.IsTemplateCached(templateName, null);
        }

        public string CreateText(string jsonString, string templateName)
        {
            var data = JsonConvert.DeserializeObject<object>(jsonString);
            try
            {
                return Engine.Razor.Run(templateName, null, data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
          
        }
    }
}
