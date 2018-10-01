using System;
using Xunit;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using WebApplication.Controllers;
using Application.Model;
using Application.BAL.Interface;
using Application.BAL;
using Application.DLL;
using Microsoft.Extensions.DependencyInjection;
using Application.DLL.Interface;

namespace XUnitTestProject1
{
    public class VehicleControllerUnitTest
    {

        public VehicleControllerUnitTest()
        {

            var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();
            Application.Util.AppSetting.init(config);




        }

        /// <summary>
        /// without filter
        /// </summary>
        [Fact]
        public void Vehicles_Filter_Test()
        {
            try
            {

                var serviceProvider = new ServiceCollection()
                     .AddSingleton<IVehicleBAL, VehicleBAL>()
                     .AddSingleton<IVehicleRepository, VehicleRepository>()
                     .BuildServiceProvider();

                VehicleDataController vehicleDataController = new VehicleDataController(null,serviceProvider.GetService<IVehicleBAL>());
                var list = vehicleDataController.Vehicles(null, null);
                Assert.IsAssignableFrom<List<Vehicle>>(list);
            }
            catch (Exception ex)
            {
                Assert.True(false);
            }

        }
        /// <summary>
        /// InActive Vehicles
        /// </summary>
        [Fact]
        public void Vehicles_Filter2_Test()
        {
            try
            {
                var serviceProvider = new ServiceCollection()
                    .AddSingleton<IVehicleBAL, VehicleBAL>()
                    .AddSingleton<IVehicleRepository, VehicleRepository>()
                    .BuildServiceProvider();

                VehicleDataController vehicleDataController = new VehicleDataController(null,serviceProvider.GetService<IVehicleBAL>());
                var list = vehicleDataController.Vehicles(null, false);
                Assert.IsAssignableFrom<List<Vehicle>>(list);
            }
            catch (Exception ex)
            {
                Assert.True(false);
            }

        }
        /// <summary>
        /// Active Vehicles
        /// </summary>
        [Fact]
        public void Vehicles_Filter3_Test()
        {
            try
            {
                var serviceProvider = new ServiceCollection()
                    .AddSingleton<IVehicleBAL, VehicleBAL>()
                    .AddSingleton<IVehicleRepository, VehicleRepository>()
                    .BuildServiceProvider();

                VehicleDataController vehicleDataController = new VehicleDataController(null,serviceProvider.GetService<IVehicleBAL>());
                var list = vehicleDataController.Vehicles(null, true);
                Assert.IsAssignableFrom<List<Vehicle>>(list);
            }
            catch (Exception ex)
            {
                Assert.True(false);
            }

        }
        /// <summary>
        /// Customer Id 1 Active Vehicles
        /// </summary>
        [Fact]
        public void Vehicles_Filter4_Test()
        {
            try
            {
                var serviceProvider = new ServiceCollection()
                    .AddSingleton<IVehicleBAL, VehicleBAL>()
                    .AddSingleton<IVehicleRepository, VehicleRepository>()
                    .BuildServiceProvider();

                VehicleDataController vehicleDataController = new VehicleDataController(null,serviceProvider.GetService<IVehicleBAL>());
                var list = vehicleDataController.Vehicles(1, true);
                Assert.IsAssignableFrom<List<Vehicle>>(list);
            }
            catch (Exception ex)
            {
                Assert.True(false);
            }

        }
        /// <summary>
        /// Get All Customers
        /// </summary>
        [Fact]
        public void Customers_Test()
        {
            try
            {

                var serviceProvider = new ServiceCollection()
                  .AddSingleton<ICustomerBAL, CustomerBAL>()
                  .AddSingleton<ICustomerRepository, CustomerRepository>()
                  .BuildServiceProvider();

                CustomerDataController customerDataController = new CustomerDataController(serviceProvider.GetService<ICustomerBAL>());

                var list = customerDataController.Customers();
                Assert.IsAssignableFrom<List<Customer>>(list);
            }
            catch (Exception ex)
            {
                Assert.True(false);
            }

        }
        /// <summary>
        /// Update Vehicle Status
        /// </summary>
        [Fact]
        public void VehicleStatusUpdate_Test()
        {
            try
            {
                var serviceProvider = new ServiceCollection()
                    .AddSingleton<IVehicleBAL, VehicleBAL>()
                    .AddSingleton<IVehicleRepository, VehicleRepository>()
                    .BuildServiceProvider();

                VehicleDataController vehicleDataController = new VehicleDataController(null,serviceProvider.GetService<IVehicleBAL>());
                bool is_success = vehicleDataController.VehicleStatusUpdate(1, true);
                Assert.True(is_success);
            }
            catch (Exception ex)
            {
                Assert.True(false);
            }
        }


        [Fact]
        public void VehicleStatusChecker_Test()
        {
            try
            {
                var serviceProvider = new ServiceCollection()
                    .AddSingleton<IVehicleBAL, VehicleBAL>()
                    .AddSingleton<IVehicleRepository, VehicleRepository>()
                    .BuildServiceProvider();

                VehicleDataController vehicleDataController = new VehicleDataController(null,serviceProvider.GetService<IVehicleBAL>());

                vehicleDataController.VehicleStatusUpdate(1, true);

                System.Threading.Thread.Sleep(65000);

                Vehicle x_Vehicle = vehicleDataController.VehiclesById(1);
                if (x_Vehicle.Status == false)
                {
                    Assert.IsAssignableFrom<Vehicle>(x_Vehicle);
                }
                else
                {
                    Assert.True(false);
                }


            }
            catch (Exception ex)
            {
                Assert.True(false);
            }
        }


    }
}
