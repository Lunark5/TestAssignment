using System;
using System.Collections.Generic;
using System.Text;
using TestAssignment.BL.Abstraction;

namespace TestAssignment.BL.Impl
{
    public sealed class ElementMerger : IElementMerger
    {
        private static ElementMerger source;
        private ElementMerger()
        { 
        }
        public static ElementMerger Get()
        {
            if (source == null)
                source = new ElementMerger();
            return source;
        }
        public IEnumerable<IElement> MergeElements(IEnumerable<IElement> elements, IElement newElement)
        {
            List<IElement> resultList = (List<IElement>)elements;
            resultList.Insert(0, newElement);        
            IElement temp;
            #region BubleSort
            for (int i = 0; i < resultList.Count; i++)
            {
                for (int j = i + 1; j < resultList.Count; j++)
                {
                    if (resultList[i].Number > resultList[j].Number)
                    {
                        temp = resultList[i];
                        resultList[i] = resultList[j];
                        resultList[j] = temp;
                    }
                }
            }
            #endregion

            for (int i = 0; i < resultList.Count; i++)
            {
                if (resultList[i].Body != newElement.Body && resultList[i].Number == newElement.Number)
                {
                    for (int j = i; j < resultList.Count && (resultList[j].Number - resultList[j - 1].Number) < 2; j++)
                    {
                        resultList[j].Number++;
                    }
                }
            }

            return resultList;
        }
    }
}
