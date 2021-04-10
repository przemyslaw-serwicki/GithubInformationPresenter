using System;

namespace GithubInformationPresenter.Models
{
    public class Committer
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime Date { get; set; }

        public override string ToString()
        {
            return $"{nameof(Committer)} - {nameof(Name)}: {Name}, {nameof(Email)}: {Email}, {nameof(Date)}: {Date}";
        }
    }
}
