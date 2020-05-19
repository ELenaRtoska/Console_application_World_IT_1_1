using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zdravo, izberi broj od slednoto meni:");
            Console.WriteLine("1) Usluzi klient");
            Console.WriteLine("2) Prodadeni karti na salter");
            Console.WriteLine("3) Vkupen promet na salter");
            Console.WriteLine("4) Site prodadeni karti na agencijata, organizairani po salter");
            Console.WriteLine("5) Vkupen promet na agencijata");
            Console.WriteLine("6) Uspesnost na agencijata");
            Console.WriteLine("7) Izlez");

            ArrayList destinacii = new ArrayList();
            destinacii.Add("Rim");
            destinacii.Add("London");
            destinacii.Add("Tokio");
            destinacii.Add("Sofija");
            destinacii.Add("Istanbul");
            destinacii.Add("Toronto");
            destinacii.Add("Majami");
            destinacii.Add("Zagreb");
            destinacii.Add("Belgrad");
            destinacii.Add("Moskva");

            int[] salteri = new int[5];
            for (int k = 0; k < 5; k++)
            {
                salteri[k] = k+1;
            }

            int[] prometSalteri = new int[5];
            for (int k = 0; k < 5; k++)
            {
                prometSalteri[k] = 0;
            }

            int[] prodadeniKartiNaSalter = new int[5];
            for (int k = 0; k < 5; k++)
            {
                prodadeniKartiNaSalter[k] = 0;
            }




            float vkupnoKlienti = 0.0f;
            float usluzeniKlienti = 0.0f;

            //datumi na prodazbi na karti
            ArrayList datumi = new ArrayList();
            //broevi na salteri kade e prodadena kartata vo soodvetniot datum
            ArrayList broeviNaSalteriPoDatum = new ArrayList();
            //prometi na salteri kade e prodadena karta vo soodveten datum
            ArrayList prometiNaSalteriPoDatum = new ArrayList();



            int i = 0;
            while (i!=7)
            {
                Console.WriteLine("Izberete broj od menito 1-7:");
                i = Int32.Parse(Console.ReadLine());
                if(i==1)
                {
                    Console.WriteLine("Vnesete ime:");
                    String ime = Console.ReadLine();
                    Console.WriteLine("Vnesete prezime:");
                    String prezime = Console.ReadLine();
                    Console.WriteLine("Vnesete godini:");
                    //int godini =Int32.Parse(Console.ReadLine()); 
                    String godini = Console.ReadLine();
                    Console.WriteLine("Vnesete destinacija:");
                    String destinacija = Console.ReadLine();

                    //proverka dali ja imame taa destinacija
                    Boolean daliDestinacija = false;
                    foreach (String item in destinacii)
                    {
                        if (item.Equals(destinacija))
                        {
                            daliDestinacija = true;
                            break;
                        }
                    }

                    //ako ja nema taa destinacija
                    if (daliDestinacija == false)
                    {
                        Console.WriteLine("Ja nemame taa destinacija");
                        vkupnoKlienti++;
                    }

                    //ako ja imame destinacijata
                    else
                    {
                        Console.WriteLine("Vnesete broj na salter: 1-5");
                        int brSalter = Int32.Parse(Console.ReadLine());
                        //dodaj promet na salter vo zavisnost od destinacija + zgolemi broj na prodadeni karti na soodvetniot salter
                        int j = 1;
                        foreach (int promet in prometSalteri)
                        {
                            if (j == brSalter)
                            {
                                int dolzinaBukvi = destinacija.Length;
                                prometSalteri[j - 1] += dolzinaBukvi * 2000;
                                prodadeniKartiNaSalter[j - 1] += 1;
                                vkupnoKlienti += 1;
                                usluzeniKlienti +=1;
                                datumi.Add(DateTime.Now);
                                broeviNaSalteriPoDatum.Add(brSalter);
                                prometiNaSalteriPoDatum.Add(dolzinaBukvi * 2000);
                                break;
                            }
                            j++;
                        }

                    }

                    

              
                    
                }







                if(i==2)
                {
                    Console.WriteLine("Vnesi broj na salter: 1-5");
                    int brSalter = Int32.Parse(Console.ReadLine());

                    Console.WriteLine("Ako sakate da doznaete kolku karti ima prodadeno na ovoj salter, potrebno e da se vnese vremenski opseg.");
                    Console.WriteLine("Vnesete SAMO pocetok na vremenskiot opseg:    (vo format mm / dd / yyyy h:m:s PM )");
                    DateTime start = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Vnesete SAMO kraj na vremenskiot opseg:     (vo format mm / dd / yyyy h:m:s PM )");
                    DateTime end = DateTime.Parse(Console.ReadLine());
                    Console.Write("Brojot na prodadeni karti vo ovoj period na ovoj salter e: ");

                    int prodadeniKartiVoOpsegot = 0;


                    int brojac = 0;
                    foreach(DateTime datum in datumi)
                    {
                        if(start <= datum && datum <= end)
                        {
                            //ispitaj dali brojot na salterot za datumot koj e validen e ist so salterot koj se bara
                            if(Int32.Parse(broeviNaSalteriPoDatum[brojac].ToString()) == brSalter)
                            {
                                prodadeniKartiVoOpsegot++;
                            }
                        }
                        brojac++;
                    }

                    Console.WriteLine(prodadeniKartiVoOpsegot);


                 
                }



                if(i == 3)
                {
                    Console.WriteLine("Vnesi broj na salter: 1-5");
                    int brSalter = Int32.Parse(Console.ReadLine());

                    Console.WriteLine("Ako sakate da doznaete kolku e vkupniot promet na ovoj salter, potrebno e da se vnese vremenski opseg.");
                    Console.WriteLine("Vnesete SAMO pocetok na vremenskiot opseg:    (vo format mm / dd / yyyy h:m:s PM )");
                    DateTime start = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Vnesete SAMO kraj na vremenskiot opseg:     (vo format mm / dd / yyyy h:m:s PM )");
                    DateTime end = DateTime.Parse(Console.ReadLine());
                    Console.Write("Vkupniot promet vo ovoj period na ovoj salter e: ");

                    int vkupenPrometVoOpsegot = 0;

                    int brojac = 0;
                    foreach (DateTime datum in datumi)
                    {
                        if (start <= datum && datum <= end)
                        {
                            //ispitaj dali brojot na salterot za datumot koj e validen e ist so salterot koj se bara
                            if (Int32.Parse(broeviNaSalteriPoDatum[brojac].ToString()) == brSalter)
                            {
                                vkupenPrometVoOpsegot += Int32.Parse(prometiNaSalteriPoDatum[brojac].ToString());
                            }
                        }
                        brojac++;
                    }
                    Console.WriteLine(vkupenPrometVoOpsegot);
                }




                if (i == 4)
                {
                    Console.WriteLine("Ako sakate da doznaete koj salter kolku karti ima prodadeno, potrebno e da se vnese vremenski opseg.");
                    Console.WriteLine("Vnesete SAMO pocetok na vremenskiot opseg:    (vo format mm / dd / yyyy h:m:s PM )");
                    DateTime start = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Vnesete SAMO kraj na vremenskiot opseg:     (vo format mm / dd / yyyy h:m:s PM )");
                    DateTime end = DateTime.Parse(Console.ReadLine());

                    int prodadeniKartiPoDatumNaSalter1 = 0;
                    int prodadeniKartiPoDatumNaSalter2 = 0;
                    int prodadeniKartiPoDatumNaSalter3 = 0;
                    int prodadeniKartiPoDatumNaSalter4 = 0;
                    int prodadeniKartiPoDatumNaSalter5 = 0;

                    int brojac = 0;
                    foreach (DateTime datum in datumi)
                    {
                        if (start <= datum && datum <= end)
                        {
                            if (Int32.Parse(broeviNaSalteriPoDatum[brojac].ToString()) == 1)
                            {
                                prodadeniKartiPoDatumNaSalter1++;
                            }
                            if (Int32.Parse(broeviNaSalteriPoDatum[brojac].ToString()) == 2)
                            {
                                prodadeniKartiPoDatumNaSalter2++;
                            }
                            if (Int32.Parse(broeviNaSalteriPoDatum[brojac].ToString()) == 3)
                            {
                                prodadeniKartiPoDatumNaSalter3++;
                            }
                            if (Int32.Parse(broeviNaSalteriPoDatum[brojac].ToString()) == 4)
                            {
                                prodadeniKartiPoDatumNaSalter4++;
                            }
                            if (Int32.Parse(broeviNaSalteriPoDatum[brojac].ToString()) == 5)
                            {
                                prodadeniKartiPoDatumNaSalter5++;
                            }

                        }
                        brojac++;
                    }
                    Console.WriteLine("Salterot so broj 1 za ovoj vremenski opseg ima prodadeno " + prodadeniKartiPoDatumNaSalter1 + " karti.");
                    Console.WriteLine("Salterot so broj 2 za ovoj vremenski opseg ima prodadeno " + prodadeniKartiPoDatumNaSalter2 + " karti.");
                    Console.WriteLine("Salterot so broj 3 za ovoj vremenski opseg ima prodadeno " + prodadeniKartiPoDatumNaSalter3 + " karti.");
                    Console.WriteLine("Salterot so broj 4 za ovoj vremenski opseg ima prodadeno " + prodadeniKartiPoDatumNaSalter4 + " karti.");
                    Console.WriteLine("Salterot so broj 5 za ovoj vremenski opseg ima prodadeno " + prodadeniKartiPoDatumNaSalter5 + " karti.");
                }




                if (i==5)
                {
                    int vkupnoPromet = 0;
                    for(int k=0;k<5;k++)
                    {
                        vkupnoPromet += prometSalteri[k];
                    }
                    Console.WriteLine("Vkupniot promet na agencijata iznesuva: " + vkupnoPromet);
                }


                if(i==6)
                {
                    float usluzenost = usluzeniKlienti / vkupnoKlienti;
                    Console.WriteLine("Uspesnosta na agencijata iznesuva: " + usluzenost);
                }



            }
        }
    }
}
