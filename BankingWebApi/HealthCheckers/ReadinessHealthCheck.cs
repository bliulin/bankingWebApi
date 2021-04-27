using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BankingWebApi.HealthCheckers
{
    public class ReadinessHealthCheck : IHealthCheck
    {
        private Uri _readinessCheckUri;

        public ReadinessHealthCheck()
        {
            string url = Path.Combine(GlobalAppSettings.BaseUrl, GlobalAppSettings.AccountsPath);
            _readinessCheckUri = new Uri(url);
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetAsync(_readinessCheckUri);
                    response.EnsureSuccessStatusCode();
                    return new HealthCheckResult(HealthStatus.Healthy);
                }
            }
            catch (Exception e)
            {
                return new HealthCheckResult(HealthStatus.Unhealthy, "HTTP call failed", e);
            }
        }
    }
}
