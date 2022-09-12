using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Acompanhamento_Web.Models;
using PagedList;
using System.Net.Mail;
using System.Net;
using Rotativa.AspNetCore;

namespace Acompanhamento_Web.Controllers
{
    public class AcompanhamentoController : Controller
    {
        private readonly AppDBContext _context;

        public AcompanhamentoController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Acompanhamento
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.Razao = String.IsNullOrEmpty(sortOrder) ? "Razao_desc" : "";
            ViewBag.Validade = sortOrder == "Validade" ? "Validade_desc" : "Validade";
            ViewBag.Dias = sortOrder == "Dias" ? "Dias_desc" : "Dias";
            ViewBag.Notificacao = sortOrder == "Notificacao" ? "Notificacao_desc" : "Notificacao";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var Acompanhamento = from s in _context.ACOMPANHAMENTO
                                 select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                Acompanhamento = from s in _context.ACOMPANHAMENTO                                 
                                 where s.RAZAO.ToUpper().Contains(searchString.ToUpper())                                 
                                 select s;
            }
            
            switch (sortOrder)
            {
                case "Razao_desc":
                    Acompanhamento = Acompanhamento.OrderByDescending(s => s.RAZAO);
                    break;
                case "Validade":
                    Acompanhamento = Acompanhamento.OrderBy(s => s.VALIDADE);
                    break;
                case "Validade_desc":
                    Acompanhamento = Acompanhamento.OrderByDescending(s => s.VALIDADE);
                    break;
                case "Dias":
                    Acompanhamento = Acompanhamento.OrderBy(s => s.DIAS);
                    break;
                case "Dias_desc":
                    Acompanhamento = Acompanhamento.OrderByDescending(s => s.DIAS);
                    break;
                case "Notificacao":
                    Acompanhamento = Acompanhamento.OrderBy(s => s.NOTIFICACAO);
                    break;
                case "Notificacao_desc":
                    Acompanhamento = Acompanhamento.OrderByDescending(s => s.NOTIFICACAO);
                    break;
                default:
                    Acompanhamento = Acompanhamento.OrderBy(s => s.VALIDADE);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(Acompanhamento.ToPagedList(pageNumber, pageSize));            
        }
        public ViewResult Index_Email(string sortOrder, string currentFilter, string searchString_email, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.Razao = String.IsNullOrEmpty(sortOrder) ? "Razao_desc" : "";
            ViewBag.Validade = sortOrder == "Validade" ? "Validade_desc" : "Validade";
            ViewBag.Dias = sortOrder == "Dias" ? "Dias_desc" : "Dias";
            ViewBag.Notificacao = sortOrder == "Notificacao" ? "Notificacao_desc" : "Notificacao";

            if (searchString_email != null)
            {
                page = 1;
            }
            else
            {
                searchString_email = currentFilter;
            }

            ViewBag.CurrentFilter = searchString_email;

            var Acompanhamento = from s in _context.ACOMPANHAMENTO
                                 select s;

            if (!String.IsNullOrEmpty(searchString_email))
            {
                Acompanhamento = from s in _context.ACOMPANHAMENTO
                                 where s.EMAIL1.ToUpper().Contains(searchString_email.ToUpper())                                 
                                 select s;
            }
            
            switch (sortOrder)
            {
                case "Razao_desc":
                    Acompanhamento = Acompanhamento.OrderByDescending(s => s.RAZAO);
                    break;
                case "Validade":
                    Acompanhamento = Acompanhamento.OrderBy(s => s.VALIDADE);
                    break;
                case "Validade_desc":
                    Acompanhamento = Acompanhamento.OrderByDescending(s => s.VALIDADE);
                    break;
                case "Dias":
                    Acompanhamento = Acompanhamento.OrderBy(s => s.DIAS);
                    break;
                case "Dias_desc":
                    Acompanhamento = Acompanhamento.OrderByDescending(s => s.DIAS);
                    break;
                case "Notificacao":
                    Acompanhamento = Acompanhamento.OrderBy(s => s.NOTIFICACAO);
                    break;
                case "Notificacao_desc":
                    Acompanhamento = Acompanhamento.OrderByDescending(s => s.NOTIFICACAO);
                    break;
                default:
                    Acompanhamento = Acompanhamento.OrderBy(s => s.VALIDADE);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(Acompanhamento.ToPagedList(pageNumber, pageSize));
        }
        public ViewResult Index_Radio(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.Razao = String.IsNullOrEmpty(sortOrder) ? "Razao_desc" : "";
            ViewBag.Validade = sortOrder == "Validade" ? "Validade_desc" : "Validade";
            ViewBag.Dias = sortOrder == "Dias" ? "Dias_desc" : "Dias";
            ViewBag.Notificacao = sortOrder == "Notificacao" ? "Notificacao_desc" : "Notificacao";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var Acompanhamento = from s in _context.ACOMPANHAMENTO
                                 where s.VALIDADE <= DateTime.Now.Date.AddDays(15)
                                 select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                Acompanhamento = from s in _context.ACOMPANHAMENTO
                                 where s.RAZAO.ToUpper().Contains(searchString.ToUpper())
                                 select s;
            }

            switch (sortOrder)
            {
                case "Razao_desc":
                    Acompanhamento = Acompanhamento.OrderByDescending(s => s.RAZAO);
                    break;
                case "Validade":
                    Acompanhamento = Acompanhamento.OrderBy(s => s.VALIDADE);
                    break;
                case "Validade_desc":
                    Acompanhamento = Acompanhamento.OrderByDescending(s => s.VALIDADE);
                    break;
                case "Dias":
                    Acompanhamento = Acompanhamento.OrderBy(s => s.DIAS);
                    break;
                case "Dias_desc":
                    Acompanhamento = Acompanhamento.OrderByDescending(s => s.DIAS);
                    break;
                case "Notificacao":
                    Acompanhamento = Acompanhamento.OrderBy(s => s.NOTIFICACAO);
                    break;
                case "Notificacao_desc":
                    Acompanhamento = Acompanhamento.OrderByDescending(s => s.NOTIFICACAO);
                    break;
                default:
                    Acompanhamento = Acompanhamento.OrderBy(s => s.VALIDADE);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(Acompanhamento.ToPagedList(pageNumber, pageSize));
        }
        public ViewResult Index_Radio2(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.Razao = String.IsNullOrEmpty(sortOrder) ? "Razao_desc" : "";
            ViewBag.Validade = sortOrder == "Validade" ? "Validade_desc" : "Validade";
            ViewBag.Dias = sortOrder == "Dias" ? "Dias_desc" : "Dias";
            ViewBag.Notificacao = sortOrder == "Notificacao" ? "Notificacao_desc" : "Notificacao";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var Acompanhamento = from s in _context.ACOMPANHAMENTO
                                 where s.VALIDADE >= DateTime.Now.Date.AddDays(15)
                                 select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                Acompanhamento = from s in _context.ACOMPANHAMENTO
                                 where s.RAZAO.ToUpper().Contains(searchString.ToUpper())
                                 select s;
            }

            switch (sortOrder)
            {
                case "Razao_desc":
                    Acompanhamento = Acompanhamento.OrderByDescending(s => s.RAZAO);
                    break;
                case "Validade":
                    Acompanhamento = Acompanhamento.OrderBy(s => s.VALIDADE);
                    break;
                case "Validade_desc":
                    Acompanhamento = Acompanhamento.OrderByDescending(s => s.VALIDADE);
                    break;
                case "Dias":
                    Acompanhamento = Acompanhamento.OrderBy(s => s.DIAS);
                    break;
                case "Dias_desc":
                    Acompanhamento = Acompanhamento.OrderByDescending(s => s.DIAS);
                    break;
                case "Notificacao":
                    Acompanhamento = Acompanhamento.OrderBy(s => s.NOTIFICACAO);
                    break;
                case "Notificacao_desc":
                    Acompanhamento = Acompanhamento.OrderByDescending(s => s.NOTIFICACAO);
                    break;
                default:
                    Acompanhamento = Acompanhamento.OrderBy(s => s.VALIDADE);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(Acompanhamento.ToPagedList(pageNumber, pageSize));
        }
        // GET: Acompanhamento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acompanhamento = await _context.ACOMPANHAMENTO
                .FirstOrDefaultAsync(m => m.ID == id);
            if (acompanhamento == null)
            {
                return NotFound();
            }

            return View(acompanhamento);
        }
        public async Task<IActionResult> CreatPDF(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acompanhamento = await _context.ACOMPANHAMENTO
                .FirstOrDefaultAsync(m => m.ID == id);
            if (acompanhamento == null)
            {
                return NotFound();
            }

            return new ViewAsPdf(acompanhamento);
        }

        // GET: Acompanhamento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Acompanhamento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CNPJ,RAZAO,VALIDADE,DIAS,NOTIFICACAO,AVISADO,ANOTACAO,EMAIL1,EMAIL2")] Acompanhamento acompanhamento)
        {
            try
            {
                string cnpj = acompanhamento.CNPJ;

                if (IsCnpj(cnpj))
                {
                    if (acompanhamento.CNPJ != null && acompanhamento.RAZAO != null && acompanhamento.VALIDADE.ToString() != null
                        && acompanhamento.EMAIL1 != null)
                    {
                        acompanhamento.NOTIFICACAO = acompanhamento.VALIDADE.AddDays(-15);

                        DateTime inicio = acompanhamento.VALIDADE;
                        DateTime fim = DateTime.Now.Date;

                        TimeSpan result = inicio - fim;

                        int Dias = Convert.ToInt16(result.ToString(@"dd"));

                        acompanhamento.DIAS = Dias;

                        if (ModelState.IsValid)
                        {
                            _context.Add(acompanhamento);
                            await _context.SaveChangesAsync();
                            ViewBag.Message = "Sucesso!!!";
                            ViewBag.title_bag = "Salvar";
                            ViewBag.type = "info";
                            //return RedirectToAction(nameof(Index));
                        }
                    }
                }
                else
                {
                    ViewBag.Message = "Confira o CNPJ digitado!!";
                    ViewBag.title_bag = "!! Cuidado !!";
                    ViewBag.type = "warning";
                    await Task.Delay(2000);                    
                }

                return View(acompanhamento);
            }
            catch (Exception)
            {
                ViewBag.Message = "CNPJ ja cadastrado no banco de dados";
                ViewBag.title_bag = "!! Cuidado !!";
                ViewBag.type = "warning";
                await Task.Delay(2000);
                return View(acompanhamento);
            }
        }

        // GET: Acompanhamento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acompanhamento = await _context.ACOMPANHAMENTO.FindAsync(id);
            if (acompanhamento == null)
            {
                return NotFound();
            }
            
            return View(acompanhamento);
        }

        // POST: Acompanhamento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,CNPJ,RAZAO,VALIDADE,DIAS,NOTIFICACAO,AVISADO,ANOTACAO,EMAIL1,EMAIL2")] Acompanhamento acompanhamento)
        {
            if (acompanhamento.RAZAO != null)
            {
                acompanhamento.RAZAO = acompanhamento.RAZAO.ToUpper();
            }

            acompanhamento.NOTIFICACAO = acompanhamento.VALIDADE.AddDays(-15);

            DateTime inicio = acompanhamento.VALIDADE;
            DateTime fim = DateTime.Now.Date;

            TimeSpan result = inicio - fim;

            int Dias = Convert.ToInt16(result.ToString(@"dd"));

            acompanhamento.DIAS = Dias;

            if (id != acompanhamento.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(acompanhamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcompanhamentoExists(acompanhamento.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction(nameof(Index));
            }
            
            return View(acompanhamento);
        }

        // GET: Acompanhamento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acompanhamento = await _context.ACOMPANHAMENTO
                .FirstOrDefaultAsync(m => m.ID == id);
            if (acompanhamento == null)
            {
                return NotFound();
            }

            return View(acompanhamento);
        }

        // POST: Acompanhamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var acompanhamento = await _context.ACOMPANHAMENTO.FindAsync(id);
            _context.ACOMPANHAMENTO.Remove(acompanhamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcompanhamentoExists(int id)
        {
            return _context.ACOMPANHAMENTO.Any(e => e.ID == id);
        }

        public async Task<IActionResult> Email(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acompanhamento = await _context.ACOMPANHAMENTO.FindAsync(id);
            if (acompanhamento == null)
            {
                return NotFound();
            }

            return View(acompanhamento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EnviaEmail()
        {
            string emailDestinatario = Request.Form["txtEmail"];
            string emailDestinatario2 = Request.Form["txtEmail2"];

            if(emailDestinatario2 == "")
            {
                emailDestinatario2 = emailDestinatario;
            }

            string razao_social = Request.Form["txtRazao"];
            SendMail(emailDestinatario, razao_social,emailDestinatario2);
            return RedirectToAction(nameof(Index));
        }

        public bool SendMail(string email, string razao, string email2)
        {
            try
            {                
                // Estancia da Classe de Mensagem
                MailMessage _mailMessage = new MailMessage();
                // Remetente
                _mailMessage.From = new MailAddress("yago@redefarmes.com.br");

                // Destinatario seta no metodo abaixo

                //Contrói o MailMessage
                _mailMessage.CC.Add(email);
                _mailMessage.CC.Add("jefferson@redefarmes.com.br");
                _mailMessage.CC.Add("suporte@redefarmes.com.br");
                _mailMessage.CC.Add("luciano@redefarmes.com.br");
                _mailMessage.CC.Add("yago@redefarmes.com.br");
                _mailMessage.To.Add(email2);
                _mailMessage.Subject = "Vencimento de Certificado Digital";
                _mailMessage.IsBodyHtml = true;
                _mailMessage.Body = "Prezado Lojista!" +
                    "<p>Informo que o Certificado Digital da " + "<b>" + razao + "</b>" + " vencerá em <b>15 dias.</b>" +
                    "<p><font color=red><b><font size=+1.5>A não renovação do mesmo em tempo hábil poderá paralisar a loja completamente.</font></b></font></p>" +
                    "<p>Esta Rede solicita que seja feito contato conosco, ao finalizar a renovação do Certificado, para que possamos atualizar o mesmo no cadastro do sistema do ACODE.</p>" +
                    "<p><b><i>Lembro que o Certificado e Senha podem ser reemetidos como resposta neste e-mail também. Trazendo assim mais comodidade para você.</i></b></p>" +
                    "<p><i>Também reiteramos a atual parceria que temos com a Empresa <b> CertificaMinas </b>, que em contrato com esta Rede, está vendendo novos Certificados Digitais para nossos lojistas no valor de <b> R$ 110,00 </b>. \n Caso opte por fazer com eles, só entrar em contato com a <b> Mayra </b> no Celular: <b> (37) 8812-9683 </b>, ou no e-mail <b> mayramorais@certificaminas.com </b></i></p>";

                string exePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);

                Attachment attachment = new Attachment(exePath + "/postredefarmes.jpg");

                _mailMessage.Attachments.Add(attachment);

                _mailMessage.Priority = MailPriority.High;

                //CONFIGURAÇÃO COM PORTA
                SmtpClient _smtpClient = new SmtpClient("smtp.office365.com", Convert.ToInt32("587"));

                //CONFIGURAÇÃO SEM PORTA
                // SmtpClient _smtpClient = new SmtpClient(UtilRsource.ConfigSmtp);

                // Credencial para envio por SMTP Seguro (Quando o servidor exige autenticação)
                _smtpClient.UseDefaultCredentials = false;
                _smtpClient.Credentials = new NetworkCredential("yago@redefarmes.com.br", "Pam42856");

                _smtpClient.EnableSsl = true;

                _smtpClient.Send(_mailMessage);

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool IsCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }
    }
}
