﻿/*  
    RapidFindReplace WPF - a find/replace control for WPF applications
    Copyright (C) 2014-2015 Keyoti Inc.

    
    This program is licensed as either free software or commercial use: 
    you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, version 2 of the License.
    Alternatively you may purchase
    a commercial license at http://keyoti.com/products/rapidfindreplace/wpf/index.html

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Keyoti.RapidFindReplace.WPF.FindHandlers.RunReaders
{
    //it is possible to handle RTB content as IContentHost using DocumentPaginator but there's a bug in WPF
    //that makes the text disappear
    //https://connect.microsoft.com/VisualStudio/feedback/details/783024
    //so treat as a FlowDocument instead

    /// <summary>
    /// IRunReader for RichTextBox.
    /// </summary>
    public class RichTextBoxRunReader : IRunReader
    {

        /// <summary>
        /// Whether this reader can read Runs from <c>runContainer</c>.
        /// </summary>
        [System.Reflection.Obfuscation(Exclude = true)]
        public static bool DoesHandle(object runContainer)
        {
            return runContainer is RichTextBox;
        }

        RichTextBox rtb;

        /// <summary>
        /// New instance.
        /// </summary>
        public RichTextBoxRunReader(RichTextBox rtb)
        {
            this.rtb = rtb;
        }

        /// <summary>
        /// Gets an enumerator that will enumerate the Runs in the element being read.
        /// </summary>
        public IEnumerator<Run> GetEnumerator()
        {
            return (new FlowDocumentRunReader(rtb.Document)).GetEnumerator();
        }
    }
}
