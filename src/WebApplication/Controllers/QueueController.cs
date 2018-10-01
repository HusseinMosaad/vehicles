using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueueController : ControllerBase
    {
        public static ConcurrentQueue<string> rueue = new ConcurrentQueue<string>();

        [HttpGet("[action]")]
        public string GetQueue()
        {

            if (rueue.Count > 0)
            {
                string dq;
                if (rueue.TryDequeue(out dq))
                {
                    return dq;
                }

            }
            return null;

        }


        [HttpGet("[action]")]
        public void AddQueue(string Vehicle_Id)
        {
            rueue.Enqueue(Vehicle_Id);
        }

        [HttpGet("[action]")]
        public int GetQueueCount()
        {
            return rueue.Count;
        }



    }
}