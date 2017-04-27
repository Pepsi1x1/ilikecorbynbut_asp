using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ILikeCorbynBut.Data;

namespace ILikeCorbynBut.Models
{
    public static class FaqExtentions
    {
        public static void EnsureSeedData(this ApplicationDbContext context)
        {
            if (!context.FaqViewModel.Any())
            {
                context.FaqViewModel.AddRange(
                    new FaqViewModel { DivId = "what-about-socialism", Question = "... isn't he a socialist?", Answer = @"Jeremy Corbyn is a <i>democratic socialist</i>. He believes that our current economic system isn't doing enough for the poor and working class in our society and that democratic change is needed to create a fairer and more just society.<br><br>But this isn't radical or scary. Many of the programs instituted by post war governments that we take for granted today &mdash; such as the NHS, the limited hours of work, the minimum wage, and Social Security &mdash; are socialist programs.", Publish = true, SubmittedOn = DateTime.Now},
                    new FaqViewModel { DivId = "position-on-nhs", Question = "...what about the NHS?", Answer = @"A Corbyn led government would:<ul><li>End health service privatisation and bring services into a secure, publicly-provided NHS.</li><li>Integrate the NHS and social care for older and disabled people.</li><li>Ensure parity for mental health services.</li><li>Re-nationalise the NHS - stop the privatisation of the NHS first introduced by in the late 90s and now aggressively pursued by the Tories</li></ul>", Publish = true, SubmittedOn = DateTime.Now },
                    new FaqViewModel { DivId = "how-will-he-fund-proposals", Question = "... how will he pay for all this?", Answer = @"Economic growth in high skill, high tech and low carbon enterprises stimulated and led by the National and Regional Investment Banks combined with changes to the tax regime (see above).", Publish = true, SubmittedOn = DateTime.Now },
                    new FaqViewModel { DivId = "how-old-is-he-again", Question = "... he's too old!", Answer = @"At 68, there have been a number of other Prime Ministers elected for their first term who were older than Jeremy Corbyn. He is now a fit and healthy 67 year old. Angela Eagle said of him during the EU Referendum that he was pursuing an agenda that would make a 25-year-old tired. He demonstrated remarkable stamina during the leadership campaign and has been described as energised at the start of this General Election campaign where he is supported by strong cabinet team of experienced politicians and campaigners.", Publish = true, SubmittedOn = DateTime.Now }
                    );
                context.SaveChanges();
            }
        }
    }
}
