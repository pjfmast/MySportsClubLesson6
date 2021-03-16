using MySportsClubLesson6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySportsClubLesson6.Services {
    // todo lesson 6-07a: IMailService interface 
    public interface IMailService {
        Task SendMailAsync(MailRequest mailRequest);
    }
}
