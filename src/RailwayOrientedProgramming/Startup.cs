using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RailwayOrientedProgramming.Startup))]
namespace RailwayOrientedProgramming
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

        }
    }
}
