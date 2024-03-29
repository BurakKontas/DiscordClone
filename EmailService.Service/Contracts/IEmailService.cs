﻿using EmailService.Domain;
using EmailService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailService.Service.Contracts
{
    public interface IEmailService
    {
        Task<Task> SendCustomEmailAsync(CustomEmailRequest request);
        Task<Task> SendConfirmationEmailAsync(AccountVerificationEmailRequest request);
        Task<Task> SendPasswordResetEmailAsync(ResetPasswordEmailRequest request);
    }
}
