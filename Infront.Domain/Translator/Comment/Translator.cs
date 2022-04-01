using Infront.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infront.Domain.Translator.Comment
{
    public static class Translator
    {
        public static CommentViewModel ViewModelTranslator(this CommentModel model)
        {
            var commentViewModel = new CommentViewModel
            {
                postId = model.postId,
                id = model.id,
                body = model.body,
                email = model.email,
                name = model.name
            };

            return commentViewModel;
        }
    }
}
