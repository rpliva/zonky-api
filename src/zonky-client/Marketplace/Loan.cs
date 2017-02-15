using System;
using System.Collections.Generic;

namespace Rpliva.Zonky.Client.Marketplace
{
    public class Loan
    {
        public Loan(int id, string name, string story, List<Photo> photos, string nickName, int termInMonths, double interestRate, string rating, object topped, double amount, double remainingInvestment, bool covered, string datePublished, bool published, string deadline, int investmentsCount, int questionsCount)
        {
            Id = id;
            Name = name;
            Story = story;
            Photos = photos;
            NickName = nickName;
            TermInMonths = termInMonths;
            InterestRate = interestRate;
            Rating = rating;
            Topped = topped;
            Amount = amount;
            RemainingInvestment = remainingInvestment;
            Covered = covered;
            DatePublished = DateTime.Parse(datePublished);
            Published = published;
            Deadline = DateTime.Parse(deadline);
            InvestmentsCount = investmentsCount;
            QuestionsCount = questionsCount;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Story { get; private set; }
        public List<Photo> Photos { get; private set; }
        public string NickName { get; private set; }
        public int TermInMonths { get; private set; }
        public double InterestRate { get; private set; }
        public string Rating { get; private set; }
        public object Topped { get; private set; }
        public double Amount { get; private set; }
        public double RemainingInvestment { get; private set; }
        public bool Covered { get; private set; }
        public DateTime DatePublished { get; private set; }
        public bool Published { get; private set; }
        public DateTime Deadline { get; private set; }
        public int InvestmentsCount { get; private set; }
        public int QuestionsCount { get; private set; }
    }
}