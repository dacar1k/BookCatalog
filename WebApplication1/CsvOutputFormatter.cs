using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;


namespace BookCatalog
{
    public class CsvOutputFormatter : TextOutputFormatter

    {
        public CsvOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }
        protected override bool CanWriteType(Type type)
        {
            if (typeof(AuthorDto).IsAssignableFrom(type) || typeof(IEnumerable<AuthorDto>).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }

            return false;
        }
        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;
            var buf = new StringBuilder();
            if (context.Object is IEnumerable<AuthorDto>)
            {
                foreach (var author in (IEnumerable<AuthorDto>)context.Object)
                {
                    FormatCsv(buf, author);
                }
            }
            else
            {
                FormatCsv(buf, (AuthorDto)context.Object);
            }
            await response.WriteAsync(buf.ToString());
        }
        private static void FormatCsv(StringBuilder buf, AuthorDto author)
        {
            buf.AppendLine($"{author.Id},\"{author.Name}");
        }

    }
}
