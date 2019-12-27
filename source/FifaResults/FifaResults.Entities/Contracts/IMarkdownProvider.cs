using System;
using System.Collections.Generic;
using System.Text;

namespace FifaResults.Entities.Contracts
{
    public interface IMarkdownProvider
    {
        string GetMarkdown();
    }
}
