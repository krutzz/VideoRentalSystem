﻿using VideoRentalSystem.Commands.Contracts;
using System.Collections.Generic;
using VideoRentalSystem.Data.Postgre.Contracts;

namespace VideoRentalSystem.Commands.PdfPrintCommands
{
    public class ListAllLoansToPdfCommand : ICommand
    {
        private readonly string fileName = @"..\..\..\LoansList.pdf";
        private readonly string imgPath = @"..\..\..\PaperAirplane.jpg";
        private readonly string title = "Loans Report";
        private readonly string header = "Loans Report";
        private readonly string author = "Triple Bounty";
        private readonly string target = "Loans";
        private readonly string keyword = "video rental system";
        private readonly string headerRental = "video rental";
        private readonly string listName = "LOANS LIST\n\n";
        private readonly string subTitle = "Who is owing cassetes to the Trible Bounty store ?";
        private readonly string warningMessage = "All customers can be procecuted without prior notice. Especially Mitko1.";

        private readonly IDatabasePostgre db;

        public ListAllLoansToPdfCommand(IDatabasePostgre db)
        {
            this.db = db;
        }

        public string Execute(IList<string> parameters)
        {
            var objectsList = this.db.Tarifs.GetAll();
            List<string> data = new List<string>();

            if (objectsList.Count == 0)
            {
                data.Add("No items");
            }

            foreach (var item in objectsList)
            {
                data.Add(item.ToString());
            }

            CreatePDF pdfCreator = new CreatePDF(
                                             this.fileName,
                                             this.imgPath,
                                             this.title,
                                             this.header,
                                             this.target,
                                             this.author,
                                             this.keyword,
                                             this.headerRental,
                                             this.listName,
                                             this.subTitle,
                                             this.warningMessage);

            pdfCreator.CreatePdf(data);

            return $"Pdf - {fileName} - with the list of all {target} was created in the project folder";
        }
    }
}