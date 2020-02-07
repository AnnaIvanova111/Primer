using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Text;


namespace WebApplication1
{

    public class Startup
    {
        public interface IMessageSender
        {
            string Send();
        }
        public class EmailMessageSender : IMessageSender
        {
            public string Send()
            {
                return "Sent by Email";
            }
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IMessageSender, EmailMessageSender>();
        }
        // Получаем зависимость IMessageSender
        public void Configure(IApplicationBuilder app, IMessageSender sender)
        {
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(sender.Send());
            });
        }
    }
}
