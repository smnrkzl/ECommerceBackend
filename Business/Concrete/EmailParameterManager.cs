﻿using Business.Abstract;
using Business.Constans;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class EmailParameterManager:IEmailParameterService
    {
        private readonly IEmailParameterDal _emailParameterDal;

        public EmailParameterManager(IEmailParameterDal emailParameterDal)
        {
            _emailParameterDal = emailParameterDal;
        }

        public IResult Add(EmailParameter emailParameter)
        {
            _emailParameterDal.Add(emailParameter);
            return new SuccessResult(EmailParameterMessages.AddedEmailParameter);
        }

        public IResult Delete(EmailParameter emailParameter)
        {
            _emailParameterDal.Delete(emailParameter);
            return new SuccessResult(EmailParameterMessages.DeletedEmailParameter);
        }

        public IDataResult<EmailParameter> GetById(int id)
        {
            return new SuccessDataResult<EmailParameter>(_emailParameterDal.Get(p => p.Id == id));
        }

        public IDataResult<List<EmailParameter>> GetList()
        {
            return new SuccessDataResult<List<EmailParameter>>(_emailParameterDal.GetAll());
        }

        public IResult SendEmail(EmailParameter emailParameter, string body, string subject, string emails)
        {
            using (MailMessage mail = new MailMessage())
            {
                string[] setEmails = emails.Split(",");
                mail.From = new MailAddress(emailParameter.Email);
                foreach (var email in setEmails)
                {
                    mail.To.Add(email);
                }
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = emailParameter.Html;
                using (SmtpClient smtp = new SmtpClient(emailParameter.Smtp))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(emailParameter.Email,emailParameter.Password);
                    smtp.EnableSsl = emailParameter.SSL;
                    smtp.Port = emailParameter.Port;
                    smtp.Send(mail);

                }
            }
            return new SuccessResult(EmailParameterMessages.EmailSendSuccesiful);
        }

        public IResult Update(EmailParameter emailParameter)
        {
            _emailParameterDal.Update(emailParameter);
            return new SuccessResult(EmailParameterMessages.UpdatedEmailParameter);
        }
    }
}
