using System;

namespace GithubInformationPresenter.Models
{
    public class GithubCommitter
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime Date { get; set; }

        public override string ToString()
        {
            return $"{nameof(GithubCommitter)} - {nameof(Name)}: {Name}, {nameof(Email)}: {Email}, {nameof(Date)}: {Date}";
        }
    }
}
