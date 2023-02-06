using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Student_Management_System_R_.Startup))]
namespace Student_Management_System_R_
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
