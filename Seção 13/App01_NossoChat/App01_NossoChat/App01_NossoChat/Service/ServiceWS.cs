using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;
using App01_NossoChat.Model;
using Newtonsoft.Json;

namespace App01_NossoChat.Service
{
    public class ServiceWS
    {
        private static string EnderecoBase = "http://ws.spacedu.com.br/xf2018/rest/api";

        public static Usuario GetUsuario(Usuario usuario)
        {
            var URL = EnderecoBase + "/usuario";

            /*
             * QueryString:
             * StringContent param = new StringContent(string.Format("?nome={0}&password{1}", usuario.nome, usuario.password
            */
            FormUrlEncodedContent param = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>( "nome", usuario.nome ),
                new KeyValuePair<string, string>( "password", usuario.password )
            });

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.PostAsync(URL, param).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                string conteudo = resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                return JsonConvert.DeserializeObject<Usuario>(conteudo);
            }
            return null;
        }

        public static List<Chat> GetChats()
        {
            var URL = EnderecoBase + "/chats";

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.GetAsync(URL).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                string conteudo = resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                if (conteudo.Length > 2)
                {
                    var lista = JsonConvert.DeserializeObject<List<Chat>>(conteudo);
                    return lista;
                }
            }

            return null;
        }

        public static bool InsertChat(Chat chat)
        {
            var URL = EnderecoBase + "/chat";

            FormUrlEncodedContent param = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>( "nome", chat.nome )
            });

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.PostAsync(URL, param).GetAwaiter().GetResult();

            return (resposta.StatusCode == HttpStatusCode.OK);
        }

        public static bool RenameChat(Chat chat)
        {
            var URL = EnderecoBase + "/chat/" + chat.id;

            FormUrlEncodedContent param = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>( "nome", chat.nome )
            });

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.PutAsync(URL, param).GetAwaiter().GetResult();

            return (resposta.StatusCode == HttpStatusCode.OK);
        }

        public static bool DeleteChat(Chat chat)
        {
            var URL = EnderecoBase + "/chat/delete" + chat.id;

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.DeleteAsync(URL).GetAwaiter().GetResult();

            return (resposta.StatusCode == HttpStatusCode.OK);
        }

        public static List<Mensagem> GetMensagensChat(Chat chat)
        {
            var URL = EnderecoBase + string.Format("/chat/{0}/msg", chat.id);

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.GetAsync(URL).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                string conteudo = resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                if (conteudo.Length > 2)
                {
                    var lista = JsonConvert.DeserializeObject<List<Mensagem>>(conteudo);
                    return lista;
                }
            }

            return null;
        }

        public static bool InsertMensagem(Mensagem mensagem)
        {
            var URL = EnderecoBase + string.Format("/chat/{0}/msg", mensagem.id_chat);

            FormUrlEncodedContent param = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>( "mensagem", mensagem.mensagem ),
                new KeyValuePair<string, string>( "id_usuario", mensagem.id_usuario.ToString() )
            });

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.PostAsync(URL, param).GetAwaiter().GetResult();

            return (resposta.StatusCode == HttpStatusCode.OK);
        }

        public static bool DeleteMensagem(Mensagem mensagem)
        {
            var URL = EnderecoBase + string.Format("/chat/{0}/delete/{1}", mensagem.id_chat, mensagem.id);

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.DeleteAsync(URL).GetAwaiter().GetResult();

            return (resposta.StatusCode == HttpStatusCode.OK);
        }
    }
}
