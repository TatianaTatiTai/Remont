using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.Logic.Common.Models.Work
{
   public class DocumentBLL
    {

        public int Id { get; set; }

        public string IdOrder { get; set; }

        /// <summary>
        /// Имя файла
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Дата сохранения текста в базу
        /// </summary>
        public DateTime? SavedDate { get; set; } = DateTime.Now;


        /// <summary>
        /// Расширение файла
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// Позиция текста при его передаче
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Сам текст
        /// </summary>
        public byte[] Text { get; set; }
    }
}
