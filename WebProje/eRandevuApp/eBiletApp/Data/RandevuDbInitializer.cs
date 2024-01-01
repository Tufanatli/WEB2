using eRandevuApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace eRandevuApp.Data
{
    public class RandevuDbInitializer
    {
        public static void EklenecekVeriler(IApplicationBuilder ab)
        {
            using(var scope = ab.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<RandevuDbContext>();

                //veritabaninin olup olmadigi kontrol ediliyor.
                context.Database.EnsureCreated();

               
                if (!context.Hastaneler.Any())
                {
                    context.Hastaneler.AddRange(new List<Hastane>()
                    {
                            new Hastane()
{
                            HastaneAdi = "Ankara Şehir Hastanesi",
                            HastaneFotografi = "~/images/Hastaneler/ankara-sehir.jpg",
                            HastaneHakkinda = "Ankara Şehir Hastanesi, Türkiye'nin başkentinde bulunan ve Avrupa'nın en büyük hastanelerinden biridir." +
                            "2018 yılında açılan bu hastane, yüksek teknolojiye sahip tıbbi cihazları ve uzman doktor kadrosuyla dikkat çekmektedir. " +
                            "Geniş bir alan üzerine kurulu olan bu hastane, çeşitli tıbbi disiplinlerde hizmet vermektedir."
                        },
                                 new Hastane()
                        {
                            HastaneAdi = "İstanbul Florence Nightingale Hastanesi",
                            HastaneFotografi = "~/images/Hastaneler/florence-nightingale.jpg",
                            HastaneHakkinda = "İstanbul Florence Nightingale Hastanesi, 1989 yılında kurulmuş ve Türkiye'nin en önemli özel hastanelerinden biri olmuştur." +
                            "Tıbbi araştırmalara ve eğitime büyük önem veren bu hastane, yüksek standartlardaki hizmetleriyle tanınmaktadır." +
                            "Modern tıbbi cihazlarla donatılmış ve birçok farklı tıbbi branşta hizmet vermektedir."
                        },
                             new Hastane()
                        {
                            HastaneAdi = "Ege Üniversitesi Tıp Fakültesi Hastanesi",
                            HastaneFotografi = "~/images/Hastaneler/ege-tip.jpg",
                            HastaneHakkinda = "Ege Üniversitesi Tıp Fakültesi Hastanesi, İzmir'de bulunan büyük bir eğitim ve araştırma hastanesidir." +
                            "Bu hastane, özellikle araştırma ve geliştirme faaliyetlerine büyük önem vermektedir." +
                            "Hem öğrencilere eğitim veren hem de geniş bir hasta kitlesine hizmet sunan bu hastane, modern tıbbi imkanlarla donatılmıştır."
                        },
                             new Hastane()
                        {
                            HastaneAdi = "Hacettepe Üniversitesi Hastaneleri",
                            HastaneFotografi = "~/images/Hastaneler/hacettepe.jpg",
                            HastaneHakkinda = "Hacettepe Üniversitesi Hastaneleri, Ankara'da bulunan ve Türkiye'nin en saygın tıbbi eğitim kurumlarından birine bağlı hastanelerdir." +
                            "Bu hastaneler, yüksek kalitede tıbbi hizmet sunmaları ve çeşitli tıbbi branşlarda uzmanlaşmış olmalarıyla tanınmaktadır." +
                            "Ayrıca, tıbbi araştırma ve gelişmelerde öncü rol oynamaktadırlar."
                        },
                                 new Hastane()
                        {
                            HastaneAdi = "Acıbadem Hastanesi",
                            HastaneFotografi = "~/images/Hastaneler/acibadem.jpg",
                            HastaneHakkinda = "Acıbadem Hastanesi, Türkiye genelinde birçok şubesi bulunan özel bir hastane zinciridir." +
                            "Modern tıbbi teknolojiler ve yüksek standartlardaki hizmet anlayışıyla dikkat çeker." +
                            "Geniş bir tıbbi branş yelpazesi sunan bu hastaneler, hastalarına kapsamlı sağlık hizmetleri sağlamaktadır."
                        }

                    });
                    context.SaveChanges();
                }

                if (!context.Doktorlar.Any())
                {
                    context.Doktorlar.AddRange(new List<doktor>()
                    {
                       new doktor()
{
                        DoktorAdSoyad = "Ayşe Yılmaz",
                        DoktorHakkinda = "1985 İstanbul doğumlu, İstanbul Üniversitesi Tıp Fakültesi mezunu. Kardiyoloji alanında uzmanlaşmış ve çeşitli araştırmalara katılmıştır.",
                        DoktorFotografi = "~/images/Doktorlar/ayseyilmaz.jpg"
},
                        new doktor()
                    {
                        DoktorAdSoyad = "Mehmet Özkan",
                        DoktorHakkinda = "1978 Ankara doğumlu, Hacettepe Üniversitesi Tıp Fakültesi mezunu. Genel cerrahi alanında deneyimli ve birçok başarılı operasyona imza atmıştır.",
                        DoktorFotografi = "~/images/Doktorlar/mehmetozkan.jpg"
                    },
                    new doktor()
                    {
                        DoktorAdSoyad = "Elif Korkmaz",
                        DoktorHakkinda = "1990 İzmir doğumlu, Ege Üniversitesi Tıp Fakültesi mezunu. Pediatri alanında uzmanlaşmış ve çocuk sağlığı konusunda çeşitli yayınlar yapmıştır.",
                        DoktorFotografi = "~/images/Doktorlar/elifkorkmaz.jpg"
                    },
                    new doktor()
                    {
                        DoktorAdSoyad = "Ahmet Demir",
                        DoktorHakkinda = "1982 Adana doğumlu, Çukurova Üniversitesi Tıp Fakültesi mezunu. Ortopedi ve travmatoloji alanında uzman, spor yaralanmaları üzerine çalışmalar yapmaktadır.",
                        DoktorFotografi = "~/images/Doktorlar/ahmetdemir.jpg"
                    },
                    new doktor()
                    {
                        DoktorAdSoyad = "Seda Aksoy",
                        DoktorHakkinda = "1975 Bursa doğumlu, Uludağ Üniversitesi Tıp Fakültesi mezunu. Göz hastalıkları alanında uzman, lazer göz cerrahisi konusunda deneyimlidir.",
                        DoktorFotografi = "~/images/Doktorlar/sedaaksoy.jpg"
                    },
                    new doktor()
                    {
                        DoktorAdSoyad = "Kemal Arslan",
                        DoktorHakkinda = "1986 Samsun doğumlu, Ondokuz Mayıs Üniversitesi Tıp Fakültesi mezunu. Nöroloji alanında uzman, beyin ve sinir hastalıkları üzerine çalışmaktadır.",
                        DoktorFotografi = "~/images/Doktorlar/kemalarslan.jpg"
                    },
                    new doktor()
                    {
                        DoktorAdSoyad = "Leyla Şahin",
                        DoktorHakkinda = "1980 Gaziantep doğumlu, Ankara Üniversitesi Tıp Fakültesi mezunu. Dermatoloji alanında uzman, cilt hastalıkları ve estetik uygulamalar konusunda deneyimlidir.",
                        DoktorFotografi = "~/images/Doktorlar/leylasahin.jpg"
                    },
                    new doktor()
                    {
                        DoktorAdSoyad = "Ekrem Selçuk Çelik",
                        DoktorHakkinda = "1983 Kayseri doğumlu, Gazi Üniversitesi Tıp Fakültesi mezunu. İç hastalıkları alanında uzman, diyabet ve hipertansiyon üzerine yoğunlaşmıştır.",
                        DoktorFotografi = "~/images/Doktorlar/ekremselcuk.jpg"
                    },
                    new doktor()
                    {
                        DoktorAdSoyad = "Banu Çetin",
                        DoktorHakkinda = "1989 Diyarbakır doğumlu, Dicle Üniversitesi Tıp Fakültesi mezunu. Kadın Hastalıkları ve Doğum alanında uzman, doğum ve kadın sağlığı üzerine çalışmalar yapmaktadır.",
                        DoktorFotografi = "~/images/Doktorlar/banucetin.jpg"
                    },
                    new doktor()
                    {
                        DoktorAdSoyad = "Emre Karataş",
                        DoktorHakkinda = "1976 Trabzon doğumlu, Karadeniz Teknik Üniversitesi Tıp Fakültesi mezunu. Psikiyatri alanında uzman, depresyon ve anksiyete bozuklukları üzerine çalışmaktadır.",
                        DoktorFotografi = "~/images/Doktorlar/emrekaratas.jpg"
                    }

                    });
                    context.SaveChanges();
                }

                if (!context.Bashekimler.Any())
                {
                    context.Bashekimler.AddRange(new List<Bashekim>()
                    {
                        new Bashekim()
                        {
                            BashekimAdSoyad = "Dr. Murat Akın",
                            BashekimHakkinda = "Dr. Murat Akın, uzun yıllar boyunca çeşitli sağlık kuruluşlarında görev yapmış, deneyimli bir cerrah ve yöneticidir." +
                            "Sağlık yönetimi alanında yüksek lisans yapmış ve birçok sağlık projesinde liderlik etmiştir." +
                            "Kariyerine, Ankara'da büyük bir devlet hastanesinin başhekim olarak devam etmektedir.",
                            BashekimFotografi = "~/images/Bashekimler/muratakin.jpg"
                        },
                        new Bashekim()
                        {
                            BashekimAdSoyad = "Dr. Elif Güneri",
                            BashekimHakkinda = "Dr. Elif Güneri, İstanbul Üniversitesi'nden mezun olduktan sonra pediatri alanında uzmanlık eğitimini tamamlamıştır." +
                            "Çocuk sağlığı ve hastalıkları konusunda geniş bir deneyime sahip olan Dr. Güneri, şu anda İstanbul'da bir özel hastanenin başhekimi olarak görev yapmaktadır.",
                            BashekimFotografi = "~/images/Bashekimler/elifguneri.jpg"
                        },
                        new Bashekim()
                        {
                            BashekimAdSoyad = "Dr. Kerem Alptekin",
                            BashekimHakkinda = "Dr. Kerem Alptekin, Ankara Üniversitesi Tıp Fakültesi mezunu olup, iç hastalıkları ve kardiyoloji alanlarında uzmanlaşmıştır." +
                            "Birçok ulusal ve uluslararası tıbbi araştırmanın yazarı olan Dr. Alptekin, Ankara'da bir devlet hastanesinin başhekimliğini yapmaktadır.",
                            BashekimFotografi = "~/images/Bashekimler/keremalptekin.jpg"
                        },
                        new Bashekim()
                        {
                            BashekimAdSoyad = "Dr. Sibel Erdem",
                            BashekimHakkinda = "Dr. Sibel Erdem, Ege Üniversitesi Tıp Fakültesi'nden mezun olup, genel cerrahi alanında uzmanlaşmıştır." +
                            "Kariyeri boyunca birçok başarılı ameliyata imza atmış olan Dr. Erdem, İzmir'de bir özel hastanenin başhekimi olarak görev yapmaktadır.",
                            BashekimFotografi = "~/images/Bashekimler/sibelerdem.jpg"
                        },
                        new Bashekim()
                        {
                            BashekimAdSoyad = "Dr. Ahmet Kaya",
                            BashekimHakkinda = "Dr. Ahmet Kaya, Hacettepe Üniversitesi Tıp Fakültesi mezunu olup, nöroloji alanında uzmanlaşmıştır." +
                            "Beyin ve sinir hastalıkları üzerine yoğunlaşan Dr. Kaya, Ankara'da bir devlet hastanesinin başhekimliğini yapmaktadır.",
                            BashekimFotografi = "~/images/Bashekimler/ahmetkaya.jpg"
                        }

                    });
                    context.SaveChanges();
                }

                if (!context.poliklinikler.Any())
                {
                    context.poliklinikler.AddRange(new List<Poliklinik>()
                    {


                        new Poliklinik()
                        {
                            PoliklinikAdi = "Gastroenteroloji Polikliniği",
                            PoliklinikHakkinda = "Gastroenteroloji polikliniğimiz, sindirim sistemi hastalıkları konusunda uzmanlaşmıştır." +
                            "Modern tanı ve tedavi yöntemleriyle hizmet veren bu poliklinik, hastalara kapsamlı gastroenterolojik bakım sağlamaktadır.",
                            FilmUcreti = 28,
                            PoliklinikFotografi = "~/images/poliklinikler/gastroenteroloji.jpg",
                            RandevuBaslamaSaati1 = "09:00",
                            RandevuBaslamaSaati2 = "11:00",
                            RandevuBaslamaSaati3 = "14:00",
                            HastaneId = 1,
                            BashekimId = 2,
                            AnaBilimDali = AnaBilimDali.Gastroenteroloji
                        },
                                    new Poliklinik()
                        {
                            PoliklinikAdi = "Kardiyoloji Polikliniği",
                            PoliklinikHakkinda = "Kardiyoloji polikliniğimiz, kalp ve damar hastalıkları konusunda uzman doktorlar tarafından hizmet vermektedir." +
                            "Modern teknoloji ile donatılmış bu poliklinik, hastalara kaliteli sağlık hizmeti sunmaktadır.",
                            FilmUcreti = 25,
                            PoliklinikFotografi = "~/images/poliklinikler/kardiyoloji.jpg",
                            RandevuBaslamaSaati1 = "08:30",
                            RandevuBaslamaSaati2 = "10:30",
                            RandevuBaslamaSaati3 = "13:30",
                            HastaneId = 2,
                            BashekimId = 4,
                            AnaBilimDali = AnaBilimDali.Kardiyoloji
                        },

                        new Poliklinik()
                        {
                            PoliklinikAdi = "Ortopedi ve Travmatoloji Polikliniği",
                            PoliklinikHakkinda = "Ortopedi ve travmatoloji polikliniğimiz, kemik, kas ve eklem sağlığına yönelik uzman hizmetler sunmaktadır." +
                            "Bu alandaki son teknolojik gelişmelerle donatılmış polikliniğimiz, hastalara kapsamlı tedavi seçenekleri sağlamaktadır.",
                            FilmUcreti = 19,
                            PoliklinikFotografi = "~/images/poliklinikler/ortopedi.jpg",
                            RandevuBaslamaSaati1 = "09:00",
                            RandevuBaslamaSaati2 = "11:00",
                            RandevuBaslamaSaati3 = "14:00",
                            HastaneId = 5,
                            BashekimId = 5,
                            AnaBilimDali = AnaBilimDali.Ortopedi
                        },

                        new Poliklinik()
                        {
                            PoliklinikAdi = "Nöroloji Polikliniği",
                            PoliklinikHakkinda = "Nöroloji polikliniğimiz, beyin, omurilik ve sinir sistemi hastalıklarının tanı ve tedavisinde uzmanlaşmıştır." +
                            "Deneyimli nöroloji ekibimiz, hastalara modern ve etkili tedavi yöntemleri sunmaktadır.",
                            FilmUcreti = 30,
                            PoliklinikFotografi = "~/images/poliklinikler/noroloji.jpg",
                            RandevuBaslamaSaati1 = "09:30",
                            RandevuBaslamaSaati2 = "11:30",
                            RandevuBaslamaSaati3 = "15:00",
                            HastaneId = 4,
                            BashekimId = 3,
                            AnaBilimDali = AnaBilimDali.Noroloji
                        },

                        new Poliklinik()
                        {
                            PoliklinikAdi = "Dermatoloji Polikliniği",
                            PoliklinikHakkinda = "Dermatoloji polikliniğimiz, cilt hastalıkları, alerjiler ve estetik dermatoloji konularında hizmet vermektedir." +
                            "Alanında uzman doktorlarımız, modern tedavi yöntemleri ile hastalara yardımcı olmaktadır.",
                            FilmUcreti = 27,
                            PoliklinikFotografi = "~/images/poliklinikler/dermatoloji.jpg",
                            RandevuBaslamaSaati1 = "10:00",
                            RandevuBaslamaSaati2 = "12:00",
                            RandevuBaslamaSaati3 = "15:30",
                            HastaneId = 2,
                            BashekimId = 3,
                            AnaBilimDali = AnaBilimDali.Dermatoloji
                        },

                        new Poliklinik()
                        {
                            PoliklinikAdi = "Endokrinoloji ve Metabolizma Hastalıkları Polikliniği",
                            PoliklinikHakkinda = "Endokrinoloji ve metabolizma hastalıkları polikliniğimiz, hormonal bozukluklar ve metabolizma hastalıkları tedavisi konusunda uzmandır." +
                            "Hastalarımıza bireyselleştirilmiş tedavi planları sunarak, sağlıklarını iyileştirmeyi amaçlamaktayız.",
                            FilmUcreti = 35,
                            PoliklinikFotografi = "~/images/poliklinikler/endokrinoloji.jpg",
                            RandevuBaslamaSaati1 = "08:00",
                            RandevuBaslamaSaati2 = "10:00",
                            RandevuBaslamaSaati3 = "13:00",
                            HastaneId = 3,
                            BashekimId = 1,
                            AnaBilimDali = AnaBilimDali.Endokrinoloji
                        }

                    });
                    context.SaveChanges();
                }
              

                if (!context.PolikliniklerDoktorlar.Any())
                {
                    context.PolikliniklerDoktorlar.AddRange(new List<PoliklinikDoktor>()
                    {
                        new PoliklinikDoktor()
                        {
                            PoliklinikId = 1,
                            DoktorId = 8
                        },

                        new PoliklinikDoktor()
                        {
                            PoliklinikId = 2,
                            DoktorId = 7
                        },

                        new PoliklinikDoktor()
                        {
                            PoliklinikId = 2,
                            DoktorId = 1
                        },

                        new PoliklinikDoktor()
                        {
                            PoliklinikId = 3,
                            DoktorId = 9
                        },

                        new PoliklinikDoktor()
                        {
                            PoliklinikId = 3,
                            DoktorId = 10
                        },

                        new PoliklinikDoktor()
                        {
                            PoliklinikId = 4,
                            DoktorId = 5
                        },
                        new PoliklinikDoktor()
                        {
                            PoliklinikId = 4,
                            DoktorId = 4
                        },
                        new PoliklinikDoktor()
                        {
                            PoliklinikId = 4,
                            DoktorId = 6
                        },
                           new PoliklinikDoktor()
                        {
                            PoliklinikId = 5,
                            DoktorId = 5
                        },
                        new PoliklinikDoktor()
                        {
                            PoliklinikId = 5,
                            DoktorId = 4
                        },
                        new PoliklinikDoktor()
                        {
                            PoliklinikId = 5,
                            DoktorId = 6
                        },
                         new PoliklinikDoktor()
                        {
                            PoliklinikId = 6,
                            DoktorId = 2
                        },
                            new PoliklinikDoktor()
                        {
                            PoliklinikId = 6,
                            DoktorId = 3
                        },

                    });
                    context.SaveChanges();
                }
            }            
        }
    
        public static async Task KullaniciVeRolEkle(IApplicationBuilder ab)
        {
            using(var scope = ab.ApplicationServices.CreateScope())
            {
                var rm = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                if(!await rm.RoleExistsAsync(Roller.Admin))
                {
                    await rm.CreateAsync(new IdentityRole(Roller.Admin));
                }
                if (!await rm.RoleExistsAsync(Roller.Kullanici))
                {
                    await rm.CreateAsync(new IdentityRole(Roller.Kullanici));
                }


                var um = scope.ServiceProvider.GetRequiredService<UserManager<Kullanici>>();
                var admin = await um.FindByEmailAsync("g211210587@ogr.sakarya.edu.tr");
                if (admin == null)
                {
                    var adminOlustur = new Kullanici()
                    {
                        AdSoyad = "Admin",
                        UserName = "admin",
                        Email = "g211210587@sakarya.edu.tr",
                        EmailConfirmed = true                   
                    };
                    await um.CreateAsync(adminOlustur, "sau");
                    await um.AddToRoleAsync(adminOlustur, Roller.Admin);
                }

                var kullanici = await um.FindByEmailAsync("g211210065@ogr.sakarya.edu.tr");
                if (kullanici == null)
                {
                    var kullaniciOlustur = new Kullanici()
                    {
                        AdSoyad = "Melih Tufan Atli",
                        UserName = "atli_",
                        Email = "g211210065@ogr.sakarya.edu.tr",
                        EmailConfirmed = true
                    };
                    await um.CreateAsync(kullaniciOlustur, "sau");
                    await um.AddToRoleAsync(kullaniciOlustur, Roller.Kullanici);
                }
            }
        }
    }
}
