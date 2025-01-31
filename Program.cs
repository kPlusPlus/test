using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

public class RSALongTextEncryption
{
    public static void Main()
    {
        // Example long text
        string longText = @"
Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec vulputate est vitae est vestibulum, id ullamcorper sapien scelerisque. Fusce commodo mattis tellus pretium condimentum. Mauris rutrum nulla cursus, aliquam nisl hendrerit, commodo est. Phasellus tincidunt sem at est pretium dignissim. Ut felis ante, pretium non congue non, egestas non sem. Cras ut pretium dui. Donec tortor est, posuere in blandit ut, condimentum non eros. Pellentesque mattis interdum molestie. Fusce viverra, nulla sit amet suscipit ultrices, felis urna consequat arcu, vitae scelerisque nibh odio ultrices urna. Sed imperdiet ante lobortis, fringilla tellus tempus, convallis felis. Praesent in vehicula lorem. Duis lacinia nisl sed sapien dignissim, mollis iaculis nibh sodales. Aliquam aliquam, ligula sed auctor bibendum, leo lorem consectetur quam, id fringilla eros ligula vitae tellus. Vivamus aliquam, diam quis pellentesque pharetra, magna libero tincidunt augue, vel condimentum urna libero in purus. Curabitur a nulla eget justo pharetra rhoncus at vehicula massa.

Pellentesque ac dolor elit. In hac habitasse platea dictumst. Ut dolor sapien, consectetur eget rhoncus semper, semper in odio. Duis et gravida elit. Praesent accumsan eros eget orci dapibus, ut volutpat turpis pharetra. Nunc volutpat, eros vel congue imperdiet, dolor velit interdum elit, vitae placerat libero orci ac ante. Duis nulla lacus, venenatis porta tempus sed, venenatis sit amet libero. Donec tincidunt tempus pretium. Morbi sed leo tincidunt augue semper rutrum et at libero. Morbi efficitur sagittis orci, id consectetur lectus posuere quis. Mauris tincidunt nec libero quis commodo. Sed tempor congue turpis sit amet lobortis. Cras congue enim id orci pellentesque, eu dapibus ipsum tempus. Sed convallis tortor sed odio viverra, eget sodales justo tincidunt. Quisque pulvinar lacus et malesuada interdum.

Maecenas non ante et dui tincidunt rutrum. Duis euismod mauris sit amet quam euismod iaculis. Donec hendrerit magna metus, at dignissim lectus ullamcorper a. Integer ac nisi facilisis, eleifend lectus eu, ultricies ex. Aliquam erat volutpat. Phasellus vehicula luctus lobortis. Cras mattis nisl vel porttitor lacinia. Nam accumsan arcu iaculis feugiat eleifend. Etiam convallis leo eu eros congue, et vulputate lectus varius. Mauris id velit non mauris ultrices vulputate at vitae arcu.

Sed vel enim lacus. Morbi ut velit ut nulla congue tincidunt. Nam sit amet dignissim orci. Donec non cursus massa. Nam sit amet quam sagittis nibh elementum interdum sed sit amet erat. Aliquam accumsan urna at velit porta, ut tempus justo scelerisque. Sed vehicula dui sed venenatis condimentum.

Pellentesque dignissim a sem iaculis placerat. Nam vitae interdum ante, a efficitur mauris. Duis viverra purus eu cursus maximus. Donec eget diam urna. Integer augue ex, pretium vitae blandit consequat, mollis a dui. Mauris hendrerit tortor orci, at varius ante commodo ullamcorper. Morbi sit amet ante euismod, varius diam id, luctus leo. Ut volutpat sed purus sed dignissim. Morbi ac tellus nec mi facilisis feugiat vitae accumsan erat. Nulla neque erat, aliquet sit amet aliquam vel, feugiat in tortor. Quisque in hendrerit ante. Duis eu euismod urna. Aliquam erat volutpat. Nulla sodales tellus nibh, sed ullamcorper felis commodo ac. Cras sagittis lectus non auctor semper. Aenean nec elementum arcu.

Phasellus a nunc eget nunc facilisis gravida nec quis sem. Praesent sit amet est nisl. In hac habitasse platea dictumst. Duis rutrum mollis mollis. Nulla ultrices ipsum nec magna hendrerit, nec placerat nibh euismod. Quisque semper ex sit amet tellus tempor fringilla. Aenean nec tempus est. Nullam mollis, est eget porttitor ultrices, felis enim ultricies est, quis porta nulla ligula a lorem. Curabitur cursus, tortor vel consequat eleifend, orci sapien convallis nulla, pharetra euismod tellus mauris ut mauris. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Proin ac sem mollis, vulputate diam nec, suscipit eros.

Sed orci nisl, aliquam vel consectetur eget, lobortis eget sem. Donec ac ante odio. Quisque blandit ac ex non aliquet. Pellentesque id mauris vel neque fermentum egestas. Nam eu tortor finibus, posuere lacus eu, semper nulla. Curabitur porttitor maximus eros, id lacinia libero convallis nec. Curabitur pellentesque blandit ex, at tempus lectus maximus nec. Nam imperdiet ultricies magna, ut aliquet quam interdum eget. Cras enim purus, accumsan in pharetra non, ullamcorper vel nibh.

Nullam ut imperdiet nibh, quis laoreet ante. Maecenas elementum justo nulla. Nam neque nulla, porttitor at fringilla vitae, porta sed nibh. Aenean egestas ac purus eu vulputate. Morbi vitae leo hendrerit, rhoncus eros quis, dignissim mi. Suspendisse ullamcorper neque sit amet massa dapibus, nec ullamcorper sapien consequat. Morbi condimentum blandit ipsum in sagittis. Aliquam ac finibus libero. Maecenas blandit at metus at faucibus. Pellentesque et porta enim, at venenatis elit. Nam a ultrices eros. Proin ullamcorper diam ut justo dictum, ac finibus augue viverra. Quisque tempus nec dui a cursus. Fusce non orci semper, eleifend metus ac, viverra velit. Sed egestas pharetra efficitur. Donec sed placerat nisi.

Donec vulputate pellentesque odio, sed consequat urna faucibus et. Aliquam ultricies efficitur ante ut tincidunt. Suspendisse consectetur nisl dui, eu elementum tellus tincidunt non. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Mauris leo urna, consequat at elit sit amet, maximus elementum libero. Pellentesque non molestie risus. Duis eget sodales turpis, ut cursus enim. Morbi luctus rutrum nulla, quis dignissim turpis sagittis ac. Nulla vitae dolor auctor, lobortis leo eget, pulvinar odio. Morbi in vulputate eros. Aliquam erat risus, feugiat eu semper non, ultrices quis mi.

Curabitur vulputate aliquam eros, non luctus mi semper eget. Nulla malesuada ipsum eros, eu malesuada odio porta vitae. Vestibulum eu rutrum arcu. Integer a tellus urna. In mattis lorem quis urna porttitor, non gravida ante suscipit. Suspendisse sed pharetra est, semper tempus mi. Integer fringilla mauris sit amet tempus fermentum. Nam consectetur dui ac dui laoreet, vel auctor dolor vehicula. Mauris mauris nulla, fermentum vel tortor sed, ultricies pharetra arcu. Nunc sollicitudin fermentum diam tempor lacinia. Sed tristique a purus ac mattis. Fusce vel leo in dolor vulputate aliquam eget quis orci. Vestibulum sapien urna, elementum et cursus ac, fringilla non neque. Pellentesque sed blandit mauris. Nullam eu libero sodales, bibendum tortor vel, scelerisque risus. Sed tincidunt ac nulla et congue.

Aliquam at accumsan lectus. Fusce ac iaculis odio. Pellentesque eleifend magna quam, nec vehicula nunc dapibus quis. Vivamus semper fermentum dui. Nunc faucibus, purus vitae iaculis porttitor, eros nisl ultricies ante, quis malesuada risus ex eget nunc. Quisque convallis id turpis sit amet tincidunt. Sed varius massa vel lacus elementum, at tincidunt magna convallis. Suspendisse potenti.

Integer ultricies tortor dictum nunc tincidunt, quis tempor nibh aliquam. Phasellus aliquet augue ut metus lacinia, vel elementum nunc bibendum. Proin gravida accumsan velit et congue. Aenean euismod eros vitae sem iaculis interdum. Sed fringilla dolor varius, pharetra turpis at, tincidunt lectus. In molestie ultrices mi vitae dapibus. Sed sodales rutrum euismod. Cras eu malesuada ligula, vel condimentum velit. Fusce ullamcorper sapien et odio maximus, vel ultricies ante rhoncus. Proin dolor nisl, hendrerit quis viverra ut, elementum in massa. Nulla non ultrices elit. Morbi commodo finibus mattis. Interdum et malesuada fames ac ante ipsum primis in faucibus. In iaculis risus eget viverra tincidunt.

Donec elementum porttitor risus, non facilisis turpis. Aliquam quis leo eget neque sollicitudin lacinia nec at ex. Integer ut ligula non erat sagittis condimentum. Ut laoreet dolor ante, eget tristique enim laoreet ut. Cras id ultricies enim, varius ornare purus. Sed id elit nulla. Suspendisse euismod tortor in fermentum sollicitudin. Sed gravida elit quis ornare faucibus. Maecenas non mollis ex, vel suscipit ligula. Curabitur mollis, diam consequat scelerisque gravida, risus magna consectetur nisi, ullamcorper cursus lectus felis et erat.

Nulla porta, nisl sed pulvinar elementum, est quam rhoncus turpis, ac consectetur urna felis ac massa. Etiam non tortor bibendum nibh vestibulum laoreet. Proin pretium arcu orci, quis euismod sem porttitor eu. Pellentesque eleifend nulla dui, non cursus purus sagittis sed. Proin rhoncus quis nisl eu malesuada. Nam dui erat, placerat sit amet fringilla quis, condimentum quis augue. In tempus enim eget nisl congue commodo nec sed elit. Donec bibendum in orci ac placerat. Proin eget orci in dolor pretium ornare nec eget eros. Sed lorem felis, bibendum feugiat arcu in, accumsan venenatis urna. Nullam fermentum est in ligula facilisis, sed sodales neque gravida. Vestibulum ex risus, pellentesque in iaculis quis, laoreet a felis. Pellentesque porttitor elit ut dolor ultrices, a tempus justo ornare. Vivamus ullamcorper nec ipsum eget ullamcorper. Suspendisse pharetra mi vitae enim elementum blandit. Duis sit amet libero congue ex lobortis elementum.

Aliquam ultrices tortor sit amet magna tincidunt, id vestibulum ipsum tempus. Donec tincidunt velit in rhoncus maximus. Nunc bibendum mi sem, rhoncus egestas magna dignissim ut. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus sed convallis arcu, non mattis urna. Morbi felis lorem, vulputate non nisl ut, mattis ornare libero. Phasellus accumsan varius odio vel faucibus. Aliquam erat volutpat. Quisque feugiat finibus velit ut dignissim. Mauris et molestie turpis. Donec sodales, elit nec accumsan mollis, nisi ex sollicitudin lectus, quis gravida elit dui venenatis velit.

Quisque quis nisi tristique, suscipit tellus congue, eleifend tortor. Sed cursus feugiat magna, quis venenatis felis mattis eu. Donec sagittis ut nisl ac convallis. Nunc ut vestibulum metus. Maecenas a ante eget nulla commodo dignissim eu non dolor. Proin congue feugiat orci ac sodales. Duis mattis sem justo, sit amet pretium dui lobortis eget. Donec non enim consequat, lacinia quam eu, sagittis erat. Ut posuere erat eu lacus volutpat, ut hendrerit lorem viverra. Pellentesque vel ipsum at est ornare commodo. Donec sed molestie tellus. Nullam aliquet nisl diam, sit amet tincidunt quam porttitor quis.

Sed ultricies orci lorem, vel pulvinar odio blandit at. Donec quis diam sed tellus convallis ornare. Suspendisse neque massa, dignissim vel elementum vitae, tempor vel ligula. Curabitur in enim quam. Mauris eget facilisis tellus. Proin eu euismod sem, in dapibus turpis. Proin ac viverra turpis, non ullamcorper massa. Integer vitae eros sit amet orci porta scelerisque. Etiam mi metus, egestas at auctor eget, dignissim et justo. Nunc eget consectetur sapien.

Duis arcu lectus, rhoncus ut augue et, pharetra euismod leo. Etiam sollicitudin sit amet ante vitae commodo. Ut varius purus suscipit eleifend suscipit. Nulla facilisi. Nunc ex erat, gravida ac tellus nec, laoreet ultrices magna. Aenean quis diam tellus. Maecenas nec faucibus diam. Integer non elementum lorem. In venenatis ex a gravida viverra. Duis ut tincidunt ex, eu rhoncus sem.

Mauris ac magna ut lacus tincidunt mollis. In venenatis eget orci ut laoreet. Cras volutpat lacus quis dolor pharetra, ac egestas diam porta. Donec vel fringilla purus. Vestibulum commodo feugiat nunc, ac varius tortor pellentesque quis. Aliquam posuere id justo non sagittis. Nullam molestie dui ut ultricies volutpat. Pellentesque ut massa dui. Aenean scelerisque lacus accumsan pharetra dapibus. Donec pharetra placerat ante, faucibus tincidunt sapien gravida sed.

Sed vehicula sapien eu lectus semper blandit. Aliquam eget sollicitudin dui, vel egestas mi. Curabitur dui enim, suscipit eget eros et, pellentesque feugiat erat. Aenean vitae est nisl. Cras a laoreet ante. Vivamus sed cursus metus. Aenean tristique risus sed auctor ornare. Sed non erat quis lorem egestas scelerisque. Vivamus volutpat nulla sit amet lorem sagittis, sed efficitur nisi malesuada. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Aenean consectetur lacinia augue, eu suscipit diam lacinia dignissim. Duis condimentum vulputate orci, id luctus est gravida eu. Morbi tincidunt aliquam purus, vitae dignissim ligula ultrices bibendum. Ut convallis congue enim vulputate sollicitudin. In tempor turpis eu iaculis iaculis.

Ut ullamcorper est sit amet ultrices convallis. Vestibulum maximus a urna in sollicitudin. Praesent nec libero quis mauris scelerisque posuere. Morbi aliquam tellus sit amet mollis rhoncus. Fusce a leo a diam imperdiet euismod et posuere enim. Etiam laoreet magna a quam facilisis sollicitudin ut mattis orci. Morbi vestibulum sagittis mattis. Praesent a urna mi. In ultrices dictum tellus ultricies malesuada. Morbi ante urna, luctus a leo vel, efficitur tristique sem. Integer iaculis metus vitae tellus semper, nec vehicula metus tempus. Integer at justo condimentum, dapibus tortor at, molestie risus. Vestibulum tempus arcu vitae urna fermentum, ut vehicula mi mollis.

Nullam ut rhoncus urna. Curabitur lacus lacus, pretium sed mi at, posuere blandit dui. Ut sagittis cursus diam at tristique. Donec lacinia arcu massa, vel convallis odio viverra ac. Suspendisse efficitur turpis et porttitor eleifend. Curabitur faucibus varius vehicula. Vivamus ac dui leo. Phasellus mollis varius ex, at varius eros imperdiet et. Integer at ipsum sit amet sem consectetur semper et nec elit. Morbi sollicitudin vestibulum ligula sit amet pulvinar. Vestibulum consequat urna vitae lacus imperdiet fermentum. In in consectetur est. Curabitur elit ligula, eleifend sit amet odio nec, molestie posuere arcu. Curabitur sodales orci in dapibus lacinia. Nullam pretium luctus nibh, vel pellentesque elit. Nam viverra quam vel malesuada semper.

Praesent congue pharetra lorem et feugiat. Fusce in auctor diam. Proin quis erat in ex placerat interdum id et justo. Praesent non dui nibh. Integer consequat lorem sapien, sit amet laoreet turpis lobortis id. Etiam semper aliquet dolor, eu porta metus rhoncus sed. Ut eu auctor nunc. Donec sed leo commodo, tincidunt lorem id, aliquam enim. Aliquam quis ante et tellus maximus luctus a vitae erat. Sed non nisi ut augue iaculis sagittis. Etiam mi justo, ornare ultrices mauris ac, luctus iaculis nibh.

Etiam vitae mattis leo, a suscipit turpis. Phasellus et pretium velit. Duis tempus diam ac ipsum aliquam volutpat. Morbi posuere est non arcu sollicitudin mollis. Cras a lectus sollicitudin, gravida dui vitae, tincidunt sapien. Mauris semper auctor euismod. Donec eget leo porta, accumsan felis sed, porttitor purus. Proin et odio est. Vivamus eu nulla id velit vestibulum egestas. Donec eros mi, bibendum in magna eu, rutrum ultricies est. Vestibulum consequat blandit libero, non hendrerit mi pharetra vel.

Pellentesque et turpis eu felis ultrices ornare. Donec a venenatis odio. Aenean aliquam molestie maximus. Mauris vitae elementum sem. Duis efficitur lacus at nisi tempus laoreet. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Etiam tempor nisl nisl, vitae auctor diam bibendum nec. Fusce id arcu sed arcu imperdiet faucibus at sed mauris. Vestibulum volutpat gravida ex non varius. Ut at lorem vel odio volutpat venenatis. Integer dolor erat, luctus sit amet dignissim vel, euismod sit amet erat. Fusce ante augue, elementum vitae neque sit amet, congue cursus est. Etiam pretium augue venenatis, malesuada lacus vel, egestas nisl. Integer blandit imperdiet mi, id porttitor purus vulputate eu. Nulla faucibus iaculis turpis eu maximus.

Curabitur scelerisque scelerisque faucibus. Praesent suscipit, arcu sit amet malesuada placerat, tellus nibh dignissim odio, eu malesuada lacus erat ut diam. Duis sollicitudin mi in risus imperdiet tincidunt. Vivamus tortor ipsum, tristique sodales ligula ac, sollicitudin dapibus massa. Praesent nec rutrum erat. Vestibulum tellus nunc, consectetur ac ipsum in, pretium convallis nisl. In in nulla gravida, malesuada est a, convallis massa. Donec cursus massa quis orci tempor feugiat. Maecenas vitae felis mattis diam laoreet egestas a a velit. Vestibulum ac lectus elit.

Ut euismod diam ut diam venenatis accumsan. Ut varius eros quis risus mollis, quis vestibulum purus scelerisque. Fusce facilisis nisl sit amet nisl rhoncus sollicitudin. Suspendisse potenti. Nulla facilisi. Nam lobortis blandit vestibulum. Maecenas massa dolor, efficitur eget hendrerit eu, dictum pellentesque mi. Mauris ut sem dui.

Donec consequat lorem libero, at mollis erat feugiat eget. Quisque maximus venenatis nulla, eget rutrum velit rhoncus in. Quisque elit magna, bibendum eget lectus bibendum, fermentum ullamcorper leo. Etiam a vulputate mauris, nec faucibus neque. Ut neque felis, aliquam sed placerat id, sagittis dapibus lectus. Sed tempus sit amet turpis vitae viverra. Curabitur ultrices vitae ipsum in convallis. Etiam eu fringilla purus. Integer eget consequat diam.

Pellentesque ultricies justo maximus, rutrum dolor et, imperdiet lacus. Suspendisse facilisis consectetur tellus, ac tristique erat molestie id. Mauris consequat varius aliquam. Vestibulum rutrum tempus elementum. Sed nunc nisl, finibus at faucibus nec, sodales et ante. Ut porta ultricies congue. Phasellus viverra a nunc at euismod. Vivamus non pulvinar nisl. Vestibulum non lorem cursus lectus ultricies tempus. Nullam sit amet lacinia urna. In hac habitasse platea dictumst. Proin condimentum dui sed leo porta porta. Nulla at arcu ut erat vulputate iaculis.

Sed in dui leo. Suspendisse vitae lacinia tellus. Donec sed risus at erat facilisis congue consequat eu nibh. Etiam ornare varius nulla, in hendrerit justo. Quisque pulvinar lorem id elit efficitur, nec elementum risus volutpat. Aliquam molestie quis ligula at interdum. Nunc condimentum ligula sed justo suscipit, vel suscipit libero tincidunt. Ut imperdiet lectus quis vestibulum finibus. ";

        // Generate RSA keys
        using (var rsa = new RSACryptoServiceProvider(2048))
        {
            rsa.PersistKeyInCsp = false;

            // Export public and private keys
            string publicKey = Convert.ToBase64String(rsa.ExportRSAPublicKey());
            string privateKey = Convert.ToBase64String(rsa.ExportRSAPrivateKey());

            // Encrypt the long text
            string encryptedText = EncryptLongText(longText, publicKey);
            Console.WriteLine("Encrypted Text: " + encryptedText);

            // Decrypt the encrypted text
            string decryptedText = DecryptLongText(encryptedText, privateKey);
            Console.WriteLine("Decrypted Text: " + decryptedText);
            Console.WriteLine("KEY " + publicKey);
        }
    }

    public static string EncryptLongText(string text, string publicKey)
    {
        using (var rsa = new RSACryptoServiceProvider())
        {
            rsa.ImportRSAPublicKey(Convert.FromBase64String(publicKey), out _);

            int maxChunkSize = (rsa.KeySize / 8) - 42; // 42 bytes for padding with OAEP
            byte[] textBytes = Encoding.UTF8.GetBytes(text);
            int offset = 0;
            var encryptedBytes = new List<byte>();

            while (offset < textBytes.Length)
            {
                int chunkSize = Math.Min(maxChunkSize, textBytes.Length - offset);
                byte[] chunk = new byte[chunkSize];
                Buffer.BlockCopy(textBytes, offset, chunk, 0, chunkSize);

                byte[] encryptedChunk = rsa.Encrypt(chunk, RSAEncryptionPadding.OaepSHA1);
                encryptedBytes.AddRange(encryptedChunk);

                offset += chunkSize;
            }

            return Convert.ToBase64String(encryptedBytes.ToArray());
        }
    }

    public static string DecryptLongText(string encryptedText, string privateKey)
    {
        using (var rsa = new RSACryptoServiceProvider())
        {
            rsa.ImportRSAPrivateKey(Convert.FromBase64String(privateKey), out _);

            byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
            int maxChunkSize = rsa.KeySize / 8;
            int offset = 0;
            var decryptedBytes = new List<byte>();

            while (offset < encryptedBytes.Length)
            {
                int chunkSize = Math.Min(maxChunkSize, encryptedBytes.Length - offset);
                byte[] chunk = new byte[chunkSize];
                Buffer.BlockCopy(encryptedBytes, offset, chunk, 0, chunkSize);

                byte[] decryptedChunk = rsa.Decrypt(chunk, RSAEncryptionPadding.OaepSHA1);
                decryptedBytes.AddRange(decryptedChunk);

                offset += chunkSize;
            }

            return Encoding.UTF8.GetString(decryptedBytes.ToArray());
        }
    }
}
