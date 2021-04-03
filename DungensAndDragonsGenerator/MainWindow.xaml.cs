using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;


namespace DungensAndDragonsGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

       


            #region HelpingVariable
            string Bonus;
        List<LevelClass> LevelAndClasses = new List<LevelClass>();
        List<MagicDamage> magicDamages = new List<MagicDamage>();
        List<WeaponDamage> weaponDamages = new List<WeaponDamage>();
        List<LootBag> lootBags = new List<LootBag>();
        List<ConditionsList> conditionsLists = new List<ConditionsList>();
        string Image;
        string WIMAGE;
        string MIMAGE;
        string LOOTIMAGE;
        SavingThrow _SavingThrow = new SavingThrow();
        Chara _Chara = new Chara();
        public static int PDFPageIndex;
        #endregion

        public MainWindow()
        {
             
            InitializeComponent();
            ComboRace.SelectionChanged += ComboRace_SelectionChanged;
            ComboSubRace.SelectionChanged += ComboSubRace_SelectionChanged;
            _ListLevelClass.SelectionChanged += _ListLevelClass_SelectionChanged;
            ComboClass.SelectionChanged += ComboClass_SelectionChanged;
            BonusText.LostKeyboardFocus += BonusText_LostKeyboardFocus;
            BonusText.KeyDown += BonusText_KeyDown;
            _Strength.KeyDown += Skill_KeyDown;
            _Dexterity.KeyDown += Skill_KeyDown;
            _Intelligens.KeyDown += Skill_KeyDown;
            _Wise.KeyDown += Skill_KeyDown;
            _Charisma.KeyDown += Skill_KeyDown;
            _Constitutiun.KeyDown += Skill_KeyDown;
            _ListMageDamage.SelectionChanged += _ListMageDamage_SelectionChanged;
            _WeaponList.SelectionChanged += _WeaponList_SelectionChanged;
            _ListLootBag.SelectionChanged += _ListLootBag_SelectionChanged;
            CondList.SelectionChanged += CondList_SelectionChanged;



            int majorVer = Environment.OSVersion.Version.Major;
            int minorVer = Environment.OSVersion.Version.Minor;

            if (majorVer == 6 && minorVer == 1)
            {
                Height = 750;
                Width = 510;
            }








        }

















        #region Menu




        private void PPDF_Click(object sender, RoutedEventArgs e)
        {
            PDFPageIndex = 1;
            PDFReader pDFReader = new PDFReader();
            pDFReader.Show();



        }

        private void DMPDF_Click(object sender, RoutedEventArgs e)
        {
            PDFPageIndex = 2;
            PDFReader pDFReader = new PDFReader();
            pDFReader.Show();
        }

        private void MMPDF_Click(object sender, RoutedEventArgs e)
        {
            PDFPageIndex = 3;
            PDFReader pDFReader = new PDFReader();
            pDFReader.Show();
        }




        private void MenuRand_Click(object sender, RoutedEventArgs e)
        {

            DiceRoller diceRoller = new DiceRoller();


            diceRoller.Show();


        }







        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            //MessageBoxResult result = MessageBox.Show("Хотите ли вы сохранить шаблон персонажа?", "Внимание!", MessageBoxButton.YesNoCancel);
            //switch (result)
            //{
            //    case MessageBoxResult.Yes:
            //        e.Cancel = true;
            //        MenuSave_ClickMess();
            //        break;
            //    case MessageBoxResult.No:

            //        break;
            //    case MessageBoxResult.Cancel:
            //        e.Cancel = true;
            //        break;

            //}



        }


        #region MenuSaveMess

        private void MenuSave_ClickMess()
        {
            int trace = 0;
            try
            {




                if (ComboRace.SelectedIndex == -1 && ComboWorldWide.SelectedIndex == -1 && ComboLevel.SelectedIndex != -1 && ComboClass.SelectedIndex != -1)
                {
                    trace = 1;
                    throw new IndexOutOfRangeException();

                }

                if (ComboRace.SelectedIndex == -1 && ComboWorldWide.SelectedIndex != -1)
                {
                    trace = 2;
                    throw new IndexOutOfRangeException();

                }

                if (ComboWorldWide.SelectedIndex == -1 && ComboRace.SelectedIndex != -1)
                {
                    trace = 3;
                    throw new IndexOutOfRangeException();
                }



                if (ComboLevel.SelectedIndex == -1 && ComboClass.SelectedIndex == -1 && ComboRace.SelectedIndex != -1 && ComboWorldWide.SelectedIndex != -1)
                {
                    trace = 4;
                    throw new IndexOutOfRangeException();

                }

                if (ComboLevel.SelectedIndex == -1 && ComboClass.SelectedIndex != -1)
                {
                    trace = 5;
                    throw new IndexOutOfRangeException();

                }


                if (ComboLevel.SelectedIndex != -1 && ComboClass.SelectedIndex == -1)
                {
                    trace = 6;
                    throw new IndexOutOfRangeException();

                }

                if (ComboLevel.SelectedIndex == -1 && ComboClass.SelectedIndex == -1 && ComboRace.SelectedIndex == -1 && ComboWorldWide.SelectedIndex == -1)
                {
                    trace = 7;
                    throw new IndexOutOfRangeException();
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.DefaultExt = "xml";
                saveFileDialog.Filter = "XML-File | *.xml";
                saveFileDialog.FilterIndex = 1;

                if (saveFileDialog.ShowDialog() == true)
                {
                    string FilePath = saveFileDialog.FileName;
                    //Personblock
                    Player player = new Player();
                    player.Person.LevelsAndClasses = LevelAndClasses;
                    player.Person.Height = _TextHeight.Text;
                    player.Person.Exp = _TextExp.Text;
                    player.Person.Name = _TextName.Text;
                    player.Person.Old = _TextOld.Text;
                    player.Person.RaceNumber = ComboRace.SelectedIndex;
                    player.Person.SubRaceNumber = ComboSubRace.SelectedIndex;
                    player.Person.WorldWideIndex = ComboWorldWide.SelectedIndex;
                    // player.Person.Weakness = _TextWeakness.Text;
                    player.Person.Weakness = new TextRange(_TextWeakness.Document.ContentStart, _TextWeakness.Document.ContentEnd).Text;
                    // player.Person.Idials = _TextIdeals.Text;
                    player.Person.Idials = new TextRange(_TextIdeals.Document.ContentStart, _TextIdeals.Document.ContentEnd).Text;
                    // player.Person.Affection = _TextAffornnes.Text;
                    player.Person.Affection = new TextRange(_TextAffornnes.Document.ContentStart, _TextAffornnes.Document.ContentEnd).Text;
                    //player.Person.Charakter = _TextChar.Text;
                    player.Person.Charakter = new TextRange(_TextChar.Document.ContentStart, _TextChar.Document.ContentEnd).Text;
                    player.Person.History = new TextRange(_TextHistory.Document.ContentStart, _TextHistory.Document.ContentEnd).Text;
                    player.Person.Wheight = _TextWeight.Text;



                    player.Person.PersonStringImage = String.IsNullOrEmpty(Image) ? PersImag.Tag.ToString() : Image;
                    //Personblock


                    //CharBlock

                    player.Charakter.MasteryBonus = BonusText.Text;
                    player.Charakter.PassiveWise = PassiveWisdom.Text;



                    player.Charakter._Abillities.Acrobatics = Acrobatic.Text;
                    player.Charakter._Abillities.AnimalHandling = AnimalHandling.Text;
                    player.Charakter._Abillities.Arcana = Arcana.Text;
                    player.Charakter._Abillities.Athletics = Athletics.Text;
                    player.Charakter._Abillities.Deception = Deception.Text;
                    player.Charakter._Abillities.History = History.Text;
                    player.Charakter._Abillities.Insight = Insight.Text;
                    player.Charakter._Abillities.Intimidation = Intimidation.Text;
                    player.Charakter._Abillities.Investigation = Investigation.Text;
                    player.Charakter._Abillities.Medicine = Medcine.Text;
                    player.Charakter._Abillities.Nature = Nature.Text;
                    player.Charakter._Abillities.Perception = Perception.Text;
                    player.Charakter._Abillities.Performance = Performance.Text;
                    player.Charakter._Abillities.Persuasion = Persuasion.Text;
                    player.Charakter._Abillities.Religion = Religion.Text;
                    player.Charakter._Abillities.SleightofHand = SleightofHand.Text;
                    player.Charakter._Abillities.Stealth = Stealth.Text;
                    player.Charakter._Abillities.Survival = Survival.Text;



                    player.Charakter._SavingThrow.Charisma = SaveChar.Text;
                    player.Charakter._SavingThrow.Constitution = SaveCons.Text;
                    player.Charakter._SavingThrow.Dexterity = SaveDex.Text;
                    player.Charakter._SavingThrow.Intelligence = SaveIntel.Text;
                    player.Charakter._SavingThrow.Strength = SaveStrengh.Text;
                    player.Charakter._SavingThrow.Wisdom = SaveWis.Text;


                    player.Charakter._Skills.Charisma = _Charisma.Text;
                    player.Charakter._Skills.Constitution = _Constitutiun.Text;
                    player.Charakter._Skills.Dexterity = _Dexterity.Text;
                    player.Charakter._Skills.Intelligence = _Intelligens.Text;
                    player.Charakter._Skills.Strength = _Strength.Text;
                    player.Charakter._Skills.Wisdom = _Wise.Text;


                    //CharBlock


                    //Constblock
                    player.Constitutiun.ArmorClass = _ArmorText.Text;
                    player.Constitutiun.Hits = _HitsText.Text;
                    player.Constitutiun.Initi = _InitiText.Text;
                    player.Constitutiun.Speed = _SpeedText.Text;
                    player.Constitutiun.Descripto = new TextRange(ConstDescripto.Document.ContentStart, ConstDescripto.Document.ContentEnd).Text;
                    //Constblock


                    //MagicDam
                    player.MagicDamegeList = magicDamages;
                    //MagicDam


                    //WeaponDamage

                    player.WeaponDamageList = weaponDamages;
                    //WeaponDamage

                    player.ConditionList = conditionsLists;

                    //LootBag

                    player.LootBagList = lootBags;
                    //LootBag

                    //Osobinosty



                    player.Osobinosti = new TextRange(OsobinostyText.Document.ContentStart, OsobinostyText.Document.ContentEnd).Text;

                    //Osobinosty


                    XmlSerializer serializer = new XmlSerializer(typeof(Player));
                    using (TextWriter tw = new StreamWriter($"{FilePath}"))
                    {
                        serializer.Serialize(tw, player);
                    }

                }

            }
            catch (IndexOutOfRangeException)
            {


                switch (trace)
                {
                    case 1:
                        {
                            MessageBox.Show("Пожалуйста заполните поле <Раса> и поле <Мировозрение>!", "Внимание!");
                        }
                        break;
                    case 2:
                        {
                            MessageBox.Show("Пожалуйста заполните поле <Раса>!", "Внимание!");
                        }
                        break;
                    case 3:
                        {
                            MessageBox.Show("Пожалуйста заполните поле <Мировозрение>!", "Внимание!");
                        }
                        break;
                    case 4:
                        {
                            MessageBox.Show("Пожалуйста заполните поле <Класс Персонажа> и поле <Уровень>!", "Внимание!");
                        }
                        break;
                    case 5:
                        {
                            MessageBox.Show("Пожалуйста заполните поле <Уровень>!", "Внимание!");
                        }
                        break;
                    case 6:
                        {
                            MessageBox.Show("Пожалуйста заполните поле <Класс Персонажа>!", "Внимание!");
                        }
                        break;
                    case 7:
                        {
                            MessageBox.Show("Пожалуйста заполните поля <Раса>, <Мировозрение>, <Класс Персонажа> и <Уровень>!", "Внимание!");
                        }
                        break;
                    default:
                        break;
                }



            }



        }


        #endregion




        public void ClearForNew()
        {
            LevelAndClasses.Clear();
            _ListLevelClass.Items.Clear();
            magicDamages.Clear();
            _ListMageDamage.Items.Clear();
            weaponDamages.Clear();
            _WeaponList.Items.Clear();
            lootBags.Clear();
            _ListLootBag.Items.Clear();
            CondList.Items.Clear();






            //PersonBlock
            _TextHeight.Text = "";
            _TextExp.Text = "";
            _TextName.Text = "";
            _TextOld.Text = "";
            ComboRace.SelectedIndex = -1;
            ComboSubRace.SelectedIndex = -1;
            ComboWorldWide.SelectedIndex = -1;
            _TextWeakness.Document.Blocks.Clear();
            _TextIdeals.Document.Blocks.Clear();
            _TextAffornnes.Document.Blocks.Clear();
            _TextChar.Document.Blocks.Clear();
            _TextHistory.Document.Blocks.Clear();
            _TextHistory.Document.Blocks.Add(new Paragraph(new Run("")));
            _TextWeight.Text = "";
            PersImag.Source = null;
            PersImagTolT.Source = null;
            //PersonBlock
            ComboClass.SelectedIndex = -1;
            ComboLevel.SelectedIndex = -1;



            //CharaBlock



            BonusText.Text = "";
            PassiveWisdom.Text = "";



            Acrobatic.Text = "";
            AnimalHandling.Text = "";
            Arcana.Text = "";
            Athletics.Text = "";
            Deception.Text = "";
            History.Text = "";
            Insight.Text = "";
            Intimidation.Text = "";
            Investigation.Text = "";
            Medcine.Text = "";
            Nature.Text = "";
            Perception.Text = "";
            Performance.Text = "";
            Persuasion.Text = "";
            Religion.Text = "";
            SleightofHand.Text = "";
            Stealth.Text = "";
            Survival.Text = "";



            SaveChar.Text = "";
            SaveCons.Text = "";
            SaveDex.Text = "";
            SaveIntel.Text = "";
            SaveStrengh.Text = "";
            SaveWis.Text = "";


            _Charisma.Text = "";
            _Constitutiun.Text = "";
            _Dexterity.Text = "";
            _Intelligens.Text = "";
            _Strength.Text = "";
            _Wise.Text = "";



            _Chara = new Chara();
            _SavingThrow = new SavingThrow();

            Bonus = "";



            _NamingText.Text = "";
            _BHZText.Text = "";
            _PowerSaveText.Text = "";
            _MagicBonusText.Text = "";
            _OpisText.Document.Blocks.Clear();




            WeapBonus.Text = "";
            WeapComboDamage.SelectedIndex = -1;
            WeapComboType.Text = "";
            WeapDescripto.Document.Blocks.Clear();
            WeapDistance.Text = "";
            WeapName.Text = "";


            LootCount.Text = "";
            LootDescr.Document.Blocks.Clear();


            //CharaBlock




            //Constblock
            TimeCond.Text = "";
            _ArmorText.Text = "";
            _HitsText.Text = "";
            _InitiText.Text = "";
            _SpeedText.Text = "";
            ConstDescripto.Document.Blocks.Clear();
            ConstDescripto.Document.Blocks.Add(new Paragraph(new Run("")));
            //Constblock


            //Osobinosti
            OsobinostyText.Document.Blocks.Clear();
            OsobinostyText.Document.Blocks.Add(new Paragraph(new Run("")));
        }


        private void MenuNew_Click(object sender, RoutedEventArgs e)
        {

            ClearForNew();

        }



        private void MenuSave_Click(object sender, RoutedEventArgs e)
        {
            int trace = 0;
            try
            {




                if (ComboRace.SelectedIndex == -1 && ComboWorldWide.SelectedIndex == -1 && ComboLevel.SelectedIndex != -1 && ComboClass.SelectedIndex != -1)
                {
                    trace = 1;
                    throw new IndexOutOfRangeException();

                }

                if (ComboRace.SelectedIndex == -1 && ComboWorldWide.SelectedIndex != -1)
                {
                    trace = 2;
                    throw new IndexOutOfRangeException();

                }

                if (ComboWorldWide.SelectedIndex == -1 && ComboRace.SelectedIndex != -1)
                {
                    trace = 3;
                    throw new IndexOutOfRangeException();
                }



                if (ComboLevel.SelectedIndex == -1 && ComboClass.SelectedIndex == -1 && ComboRace.SelectedIndex != -1 && ComboWorldWide.SelectedIndex != -1)
                {
                    trace = 4;
                    throw new IndexOutOfRangeException();

                }

                if (ComboLevel.SelectedIndex == -1 && ComboClass.SelectedIndex != -1)
                {
                    trace = 5;
                    throw new IndexOutOfRangeException();

                }


                if (ComboLevel.SelectedIndex != -1 && ComboClass.SelectedIndex == -1)
                {
                    trace = 6;
                    throw new IndexOutOfRangeException();

                }

                if (ComboLevel.SelectedIndex == -1 && ComboClass.SelectedIndex == -1 && ComboRace.SelectedIndex == -1 && ComboWorldWide.SelectedIndex == -1)
                {
                    trace = 7;
                    throw new IndexOutOfRangeException();
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.DefaultExt = "xml";
                saveFileDialog.Filter = "XML-File | *.xml";
                saveFileDialog.FilterIndex = 1;
                string Path = null;
                if (saveFileDialog.ShowDialog() == true)
                {
                    Path = saveFileDialog.FileName;
                    //Personblock
                    Player player = new Player();
                    player.Person.LevelsAndClasses = LevelAndClasses;
                    player.Person.Height = _TextHeight.Text;
                    player.Person.Exp = _TextExp.Text;
                    player.Person.Name = _TextName.Text;
                    player.Person.Old = _TextOld.Text;
                    player.Person.RaceNumber = ComboRace.SelectedIndex;
                    player.Person.SubRaceNumber = ComboSubRace.SelectedIndex;
                    player.Person.WorldWideIndex = ComboWorldWide.SelectedIndex;
                    // player.Person.Weakness = _TextWeakness.Text;
                    player.Person.Weakness = new TextRange(_TextWeakness.Document.ContentStart, _TextWeakness.Document.ContentEnd).Text;
                    // player.Person.Idials = _TextIdeals.Text;
                    player.Person.Idials = new TextRange(_TextIdeals.Document.ContentStart, _TextIdeals.Document.ContentEnd).Text;
                    // player.Person.Affection = _TextAffornnes.Text;
                    player.Person.Affection = new TextRange(_TextAffornnes.Document.ContentStart, _TextAffornnes.Document.ContentEnd).Text;
                    //player.Person.Charakter = _TextChar.Text;
                    player.Person.Charakter = new TextRange(_TextChar.Document.ContentStart, _TextChar.Document.ContentEnd).Text;
                    player.Person.History = new TextRange(_TextHistory.Document.ContentStart, _TextHistory.Document.ContentEnd).Text;
                    player.Person.Wheight = _TextWeight.Text;
                  

                    
                    player.Person.PersonStringImage = Image;
                    //Personblock
                    
                    
                    //CharBlock

                    player.Charakter.MasteryBonus = BonusText.Text;
                    player.Charakter.PassiveWise = PassiveWisdom.Text;



                    player.Charakter._Abillities.Acrobatics = Acrobatic.Text;
                    player.Charakter._Abillities.AnimalHandling = AnimalHandling.Text;
                    player.Charakter._Abillities.Arcana = Arcana.Text;
                    player.Charakter._Abillities.Athletics = Athletics.Text;
                    player.Charakter._Abillities.Deception = Deception.Text;
                    player.Charakter._Abillities.History = History.Text;
                    player.Charakter._Abillities.Insight = Insight.Text;
                    player.Charakter._Abillities.Intimidation = Intimidation.Text;
                    player.Charakter._Abillities.Investigation = Investigation.Text;
                    player.Charakter._Abillities.Medicine = Medcine.Text;
                    player.Charakter._Abillities.Nature = Nature.Text;
                    player.Charakter._Abillities.Perception = Perception.Text;
                    player.Charakter._Abillities.Performance = Performance.Text;
                    player.Charakter._Abillities.Persuasion = Persuasion.Text;
                    player.Charakter._Abillities.Religion = Religion.Text;
                    player.Charakter._Abillities.SleightofHand = SleightofHand.Text;
                    player.Charakter._Abillities.Stealth = Stealth.Text;
                    player.Charakter._Abillities.Survival = Survival.Text;



                    player.Charakter._SavingThrow.Charisma = SaveChar.Text;
                    player.Charakter._SavingThrow.Constitution = SaveCons.Text;
                    player.Charakter._SavingThrow.Dexterity = SaveDex.Text;
                    player.Charakter._SavingThrow.Intelligence = SaveIntel.Text;
                    player.Charakter._SavingThrow.Strength = SaveStrengh.Text;
                    player.Charakter._SavingThrow.Wisdom = SaveWis.Text;


                    player.Charakter._Skills.Charisma = _Charisma.Text;
                    player.Charakter._Skills.Constitution = _Constitutiun.Text;
                    player.Charakter._Skills.Dexterity = _Dexterity.Text;
                    player.Charakter._Skills.Intelligence = _Intelligens.Text;
                    player.Charakter._Skills.Strength = _Strength.Text;
                    player.Charakter._Skills.Wisdom = _Wise.Text;


                    //CharBlock


                    //Constblock
                    player.Constitutiun.ArmorClass = _ArmorText.Text;
                    player.Constitutiun.Hits = _HitsText.Text;
                    player.Constitutiun.Initi = _InitiText.Text;
                    player.Constitutiun.Speed = _SpeedText.Text;
                    player.Constitutiun.Descripto= new TextRange(ConstDescripto.Document.ContentStart, ConstDescripto.Document.ContentEnd).Text;
                    //Constblock


                    //MagicDam
                    player.MagicDamegeList = magicDamages;
                    //MagicDam


                    //WeaponDamage

                    player.WeaponDamageList = weaponDamages;
                    //WeaponDamage

                    player.ConditionList = conditionsLists;

                    //LootBag

                    player.LootBagList = lootBags;
                    //LootBag

                    //Osobinosty



                    player.Osobinosti = new TextRange(OsobinostyText.Document.ContentStart, OsobinostyText.Document.ContentEnd).Text;

                    //Osobinosty


                    XmlSerializer serializer = new XmlSerializer(typeof(Player));
                    using (TextWriter tw = new StreamWriter($"{saveFileDialog.FileName}"))
                    {
                        serializer.Serialize(tw, player);
                    }

                }

            }
            catch (IndexOutOfRangeException)
            {


                switch (trace)
                {
                    case 1:
                        {
                            MessageBox.Show("Пожалуйста заполните поле <Раса> и поле <Мировозрение>!", "Внимание!");
                        }
                        break;
                    case 2:
                        {
                            MessageBox.Show("Пожалуйста заполните поле <Раса>!", "Внимание!");
                        }
                        break;
                    case 3:
                        {
                            MessageBox.Show("Пожалуйста заполните поле <Мировозрение>!", "Внимание!");
                        }
                        break;
                    case 4:
                        {
                            MessageBox.Show("Пожалуйста заполните поле <Класс Персонажа> и поле <Уровень>!", "Внимание!");
                        }
                        break;
                    case 5:
                        {
                            MessageBox.Show("Пожалуйста заполните поле <Уровень>!", "Внимание!");
                        }
                        break;
                    case 6:
                        {
                            MessageBox.Show("Пожалуйста заполните поле <Класс Персонажа>!", "Внимание!");
                        }
                        break;
                    case 7:
                        {
                            MessageBox.Show("Пожалуйста заполните поля <Раса>, <Мировозрение>, <Класс Персонажа> и <Уровень>!", "Внимание!");
                        }
                        break;
                    default:
                        break;
                }



            }

        }



        

        private void MenuOpen_Click(object sender, RoutedEventArgs e)
        {




            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML-File | *.xml";

            if (openFileDialog.ShowDialog() == true)
            {
                ClearForNew();
                string FilePath = openFileDialog.FileName;
                XmlSerializer xmldeserializer = new XmlSerializer(typeof(Player));
                Player player = new Player();
                using (TextReader reader = new StreamReader(FilePath))
                {


                    object FileInfo = xmldeserializer.Deserialize(reader);
                    player = (Player)FileInfo;

                }


                LevelAndClasses = player.Person.LevelsAndClasses;
                foreach (var item in LevelAndClasses)
                {

                    _ListLevelClass.Items.Add($"Класс :{item.Class}\nУровень: {item.Level}");
                }

                magicDamages = player.MagicDamegeList;
                foreach (var item in magicDamages)
                {

                    _ListMageDamage.Items.Add($"Название и Описание: {item.Naming}\nБазовая Характеристика Заклинания: {item.BaseChar}\nСила спасброска: {item.SavePower}\nБонус атаки: {item.MagicDamageBonus}\nОписание: {item.Opis}");


                }
                weaponDamages = player.WeaponDamageList;

                foreach (var item in weaponDamages)
                {

                    _WeaponList.Items.Add($"Название: {item.Naming}\nУрон: {item.Damage}\nБонус Атаки: {item.Bonus}\nДистанция: {item.Distance}\nВид: {item.Type}\nОписание: {item.Descripto}");


                }


                lootBags = player.LootBagList;


                foreach (var item in lootBags)
                {


                    _ListLootBag.Items.Add($"Описание: {item.Description}\nКоличество: {item.Count}");


                }
                conditionsLists = player.ConditionList;

                foreach (var item in conditionsLists)
                {
                    CondList.Items.Add($"Эффект: {item.Effect}\nДлительность: {item.Time}");
                }




                //PersonBlock
                _TextHeight.Text = player.Person.Height;
                _TextExp.Text = player.Person.Exp;
                _TextName.Text = player.Person.Name;
                _TextOld.Text = player.Person.Old;
                ComboRace.SelectedIndex = player.Person.RaceNumber;
                ComboSubRace.SelectedIndex = player.Person.SubRaceNumber;
                ComboWorldWide.SelectedIndex = player.Person.WorldWideIndex;
                // _TextWeakness.Text = player.Person.Weakness;
                _TextWeakness.Document.Blocks.Add(new Paragraph(new Run(player.Person.Weakness)));
                // _TextIdeals.Text = player.Person.Idials;
                _TextIdeals.Document.Blocks.Add(new Paragraph(new Run(player.Person.Idials)));
                //_TextAffornnes.Text = player.Person.Affection;
                _TextAffornnes.Document.Blocks.Add(new Paragraph(new Run(player.Person.Affection)));
                //_TextChar.Text = player.Person.Charakter;
                _TextChar.Document.Blocks.Add(new Paragraph(new Run(player.Person.Charakter)));
                _TextHistory.Document.Blocks.Clear();
                _TextHistory.Document.Blocks.Add(new Paragraph(new Run(player.Person.History)));
                _TextWeight.Text = player.Person.Wheight;



                PersImag.Tag = player.Person.PersonStringImage;
                PersImag.Source = player.Person.PersonImage;
                PersImagTolT.Source= player.Person.PersonImage;
                Image = player.Person.PersonStringImage;
                //PersonBlock



                //CharaBlock



                BonusText.Text = player.Charakter.MasteryBonus;
                PassiveWisdom.Text = player.Charakter.PassiveWise;



                Acrobatic.Text = player.Charakter._Abillities.Acrobatics;
                AnimalHandling.Text = player.Charakter._Abillities.AnimalHandling;
                Arcana.Text = player.Charakter._Abillities.Arcana;
                Athletics.Text = player.Charakter._Abillities.Athletics;
                Deception.Text = player.Charakter._Abillities.Deception;
                History.Text = player.Charakter._Abillities.History;
                Insight.Text = player.Charakter._Abillities.Insight;
                Intimidation.Text = player.Charakter._Abillities.Intimidation;
                Investigation.Text = player.Charakter._Abillities.Investigation;
                Medcine.Text = player.Charakter._Abillities.Medicine;
                Nature.Text = player.Charakter._Abillities.Nature;
                Perception.Text = player.Charakter._Abillities.Perception;
                Performance.Text = player.Charakter._Abillities.Performance;
                Persuasion.Text = player.Charakter._Abillities.Persuasion;
                Religion.Text = player.Charakter._Abillities.Religion;
                SleightofHand.Text = player.Charakter._Abillities.SleightofHand;
                Stealth.Text = player.Charakter._Abillities.Stealth;
                Survival.Text = player.Charakter._Abillities.Survival;



                SaveChar.Text = player.Charakter._SavingThrow.Charisma;
                SaveCons.Text = player.Charakter._SavingThrow.Constitution;
                SaveDex.Text = player.Charakter._SavingThrow.Dexterity;
                SaveIntel.Text = player.Charakter._SavingThrow.Intelligence;
                SaveStrengh.Text = player.Charakter._SavingThrow.Strength;
                SaveWis.Text = player.Charakter._SavingThrow.Wisdom;


                _Charisma.Text = player.Charakter._Skills.Charisma;
                _Constitutiun.Text = player.Charakter._Skills.Constitution;
                _Dexterity.Text = player.Charakter._Skills.Dexterity;
                _Intelligens.Text = player.Charakter._Skills.Intelligence;
                _Strength.Text = player.Charakter._Skills.Strength;
                _Wise.Text = player.Charakter._Skills.Wisdom;



                _Chara = player.Charakter;
                _SavingThrow = player.Charakter._SavingThrow;

                if (player.Person.LevelsAndClasses.Count != 0)
                {
                    if (int.TryParse(player.Person.LevelsAndClasses[0].Class, out int result))
                    {

                        _SaveThrowTextts.DataContext = SavingThrowByClass(result);

                    }
                    else
                    {

                    }

                }
                Bonus = player.Charakter.MasteryBonus;

                if (_ListLevelClass.Items != null)
                {
                    _ListLevelClass.SelectedIndex = 0;
                }







                //CharaBlock




                //Constblock
                _ArmorText.Text = player.Constitutiun.ArmorClass;
                _HitsText.Text = player.Constitutiun.Hits;
                _InitiText.Text = player.Constitutiun.Initi;
                _SpeedText.Text = player.Constitutiun.Speed;
                ConstDescripto.Document.Blocks.Add(new Paragraph(new Run(player.Constitutiun.Descripto)));
                //Constblock


                //Osobinosti
                OsobinostyText.Document.Blocks.Clear();
                OsobinostyText.Document.Blocks.Add(new Paragraph(new Run(player.Osobinosti)));


            }





        }










        #endregion

        #region PersonalBlock
        private void _ListLevelClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_ListLevelClass.SelectedIndex != -1)
            {


                int index;
                switch (LevelAndClasses[_ListLevelClass.SelectedIndex].Class)
                {

                    case "Варвар":
                        {
                            index = 0;
                        }
                        break;
                    case "Бард":
                        {
                            index = 1;
                        }
                        break;
                    case "Жрец":
                        {
                            index = 2;
                        }
                        break;
                    case "Друид":
                        {
                            index = 3;
                        }
                        break;
                    case "Воин":
                        {
                            index = 4;
                        }
                        break;
                    case "Монах":
                        {
                            index = 5;
                        }
                        break;
                    case "Паладин":
                        {
                            index = 6;
                        }
                        break;
                    case "Следопыт":
                        {
                            index = 7;
                        }
                        break;
                    case "Плут":
                        {
                            index = 8;
                        }
                        break;
                    case "Чародей":
                        {
                            index = 9;
                        }
                        break;
                    case "Колдун":
                        {
                            index = 10;
                        }
                        break;
                    case "Волшебник":
                        {
                            index = 11;
                        }
                        break;
                    default:
                        index = 0;
                        break;
                }




                ComboClass.SelectedIndex = index;

                switch (LevelAndClasses[_ListLevelClass.SelectedIndex].Level)
                {


                    case "1":
                        {
                            index = 0;
                        }
                        break;
                    case "2":
                        {
                            index = 1;
                        }
                        break;
                    case "3":
                        {
                            index = 2;
                        }
                        break;
                    case "4":
                        {
                            index = 3;
                        }
                        break;
                    case "5":
                        {
                            index = 4;
                        }
                        break;
                    case "6":
                        {
                            index = 5;
                        }
                        break;
                    case "7":
                        {
                            index = 6;
                        }
                        break;
                    case "8":
                        {
                            index = 7;
                        }
                        break;
                    case "9":
                        {
                            index = 8;
                        }
                        break;
                    case "10":
                        {
                            index = 9;
                        }
                        break;
                    case "11":
                        {
                            index = 10;
                        }
                        break;
                    case "12":
                        {
                            index = 11;
                        }
                        break;
                    case "13":
                        {
                            index = 12;
                        }
                        break;
                    case "14":
                        {
                            index = 13;
                        }
                        break;
                    case "15":
                        {
                            index = 14;
                        }
                        break;
                    case "16":
                        {
                            index = 15;
                        }
                        break;
                    case "17":
                        {
                            index = 16;
                        }
                        break;
                    case "18":
                        {
                            index = 17;
                        }
                        break;
                    case "19":
                        {
                            index = 18;
                        }
                        break;
                    case "20":
                        {
                            index = 19;
                        }
                        break;

                    default:
                        index = 0;
                        break;
                }

                ComboLevel.SelectedIndex = index;

            }
        }

        private void ComboClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            _BonusSrow.DataContext = SavingThrowByClass(ComboClass.SelectedIndex);

        }



        private SavingThrow SavingThrowByClass(int index)
        {
            int zero = 0;
            int bonus;
            if (String.IsNullOrEmpty(Bonus))
            {
                bonus = 2;
            }
            else if (int.TryParse(Bonus, out int result))
            {
                if (result < 2)
                {
                    bonus = 2;

                }
                else
                {
                    bonus = result;
                }

            }
            else
            {
                bonus = 2;
            }

            switch (index)
            {

                case 0:
                    {
                        return new SavingThrow(bonus.ToString(), zero.ToString(), bonus.ToString(), zero.ToString(), zero.ToString(), zero.ToString());
                    }
                case 1:
                    {
                        return new SavingThrow(zero.ToString(), bonus.ToString(), zero.ToString(), zero.ToString(), zero.ToString(), bonus.ToString());
                    }
                case 2:
                    {
                        return new SavingThrow(zero.ToString(), zero.ToString(), zero.ToString(), zero.ToString(), bonus.ToString(), bonus.ToString());
                    }
                case 3:
                    {
                        return new SavingThrow(zero.ToString(), zero.ToString(), zero.ToString(), bonus.ToString(), bonus.ToString(), zero.ToString());

                    }
                case 4:
                    {
                        return new SavingThrow(bonus.ToString(), zero.ToString(), bonus.ToString(), zero.ToString(), zero.ToString(), zero.ToString());

                    }
                case 5:
                    {
                        return new SavingThrow(bonus.ToString(), bonus.ToString(), zero.ToString(), zero.ToString(), zero.ToString(), zero.ToString());

                    }
                case 6:
                    {
                        return new SavingThrow(zero.ToString(), zero.ToString(), zero.ToString(), zero.ToString(), bonus.ToString(), bonus.ToString());
                    }
                case 7:
                    {
                        return new SavingThrow(bonus.ToString(), bonus.ToString(), zero.ToString(), zero.ToString(), zero.ToString(), zero.ToString());

                    }
                case 8:
                    {
                        return new SavingThrow(zero.ToString(), bonus.ToString(), zero.ToString(), bonus.ToString(), zero.ToString(), zero.ToString());

                    }
                case 9:
                    {
                        return new SavingThrow(zero.ToString(), zero.ToString(), bonus.ToString(), zero.ToString(), zero.ToString(), bonus.ToString());

                    }
                case 10:
                    {
                        return new SavingThrow(zero.ToString(), zero.ToString(), zero.ToString(), zero.ToString(), bonus.ToString(), bonus.ToString());

                    }
                case 11:
                    {
                        return new SavingThrow(zero.ToString(), zero.ToString(), zero.ToString(), bonus.ToString(), bonus.ToString(), zero.ToString());

                    }

                default:
                    return null;

            }




        }



        private void ComboSubRace_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboSubRace.SelectedIndex != -1)
            {


                _SaveThrowTextts.DataContext = new StringStatusBonus(DnDRaces.DNDGetStatus(ComboRace.SelectedIndex, ComboSubRace.SelectedIndex), ComboRace.SelectedIndex);
               TextHitsBonus.Text = new StringStatusBonus(DnDRaces.DNDGetStatus(ComboRace.SelectedIndex, ComboSubRace.SelectedIndex), ComboRace.SelectedIndex).Hits;
               InfoText.Text = new StringStatusBonus(DnDRaces.DNDGetStatus(ComboRace.SelectedIndex, ComboSubRace.SelectedIndex), ComboRace.SelectedIndex).Info;
               _SpeedText.Text = new StringStatusBonus(DnDRaces.DNDGetStatus(ComboRace.SelectedIndex, ComboSubRace.SelectedIndex), ComboRace.SelectedIndex).Speed;
            }
            else
            {

                _SaveThrowTextts.DataContext = new StringStatusBonus(new StatusBonus(0, 0, 0, 0, 0, 0, 0, 0, ""));



            }
        }

        private void ComboRace_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            ComboSubRace.ItemsSource = DnDRaces.DNDGetRace(ComboRace.SelectedIndex);
            ComboSubRace.SelectedIndex = 0;
        }



        private void AddToLevelClassList_Click(object sender, RoutedEventArgs e)
        {

            if (ComboClass.SelectedIndex != -1 && ComboLevel.SelectedIndex != -1)
            {



                LevelAndClasses.Add(new LevelClass(ComboLevel.Text, ComboClass.Text));



                string item = $"Класс :{ComboClass.Text}\nУровень: {ComboLevel.Text}";




                _ListLevelClass.Items.Add(item);






            }


        }



        private void SaveAdd_Click(object sender, RoutedEventArgs e)
        {

            if (_ListLevelClass.SelectedIndex != -1)
            {


                LevelAndClasses[_ListLevelClass.SelectedIndex].Class = ComboClass.Text;
                LevelAndClasses[_ListLevelClass.SelectedIndex].Level = ComboLevel.Text;


                string item = $"Класс :{ComboClass.Text}\nУровень: {ComboLevel.Text}";

                _ListLevelClass.Items[_ListLevelClass.SelectedIndex] = item;

            }







        }

        private void Delet_Click(object sender, RoutedEventArgs e)
        {
            if (_ListLevelClass.SelectedIndex != -1)
            {


                var index = _ListLevelClass.SelectedIndex;
                string item = $"Класс :{ComboClass.Text}\nУровень: {ComboLevel.Text}";
                LevelAndClasses.Remove(LevelAndClasses[index]);
                _ListLevelClass.Items.Remove(item);
            }



        }



        private void _FotoButt_Click(object sender, RoutedEventArgs e)
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (openFileDialog.ShowDialog() == true)
            {


                Image = PersonaBlock.ImgToStr(openFileDialog.FileName);
                PersImag.Source = PersonaBlock.BitmapToImageSourceS((Bitmap)PersonaBlock.StrToImg(Image));
                PersImag.Tag = Image;
                PersImagTolT.Source = PersonaBlock.BitmapToImageSourceS((Bitmap)PersonaBlock.StrToImg(Image));



            }

        }








        #endregion

        #region SkillBlock

        private void BonusText_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            Bonus = BonusText.Text;
            _BonusSrow.DataContext = SavingThrowByClass(ComboClass.SelectedIndex);

        }

        private void BonusText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {


                Bonus = BonusText.Text;
                _BonusSrow.DataContext = SavingThrowByClass(ComboClass.SelectedIndex);

            }
        }

        private void Skill_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                int variable;
                string Text = null;
                var Box = (TextBox)sender;


                if (!String.IsNullOrEmpty(Box.Text))
                {
                    if (int.TryParse(Box.Text, out int result))
                    {
                        variable = result;
                    }
                    else if (int.TryParse(Box.Text.Substring(0, 2), out int res))
                    {

                        variable = res;

                    }
                    else if (int.TryParse(Box.Text.Substring(0, 1), out int ress))
                    {
                        variable = ress;
                    }
                    else
                    {
                        variable = 0;
                    }

                    if (variable > 30 || variable < 0)
                    {
                        variable = 0;
                    }

                    Text = Func_Skill(variable);
                    Box.Text = Text;


                    switch (Box.Name)
                    {
                        case "_Strength":
                            {
                                _Chara._Abillities.Athletics = Func_Skill_Char(variable);
                                _SavingThrow.Strength = Func_Skill_Char(variable);

                            }
                            break;
                        case "_Dexterity":
                            {
                                _Chara._Abillities.Acrobatics = Func_Skill_Char(variable);
                                _Chara._Abillities.SleightofHand = Func_Skill_Char(variable);
                                _Chara._Abillities.Stealth = Func_Skill_Char(variable);
                                _SavingThrow.Dexterity = Func_Skill_Char(variable);
                            }
                            break;
                        case "_Constitutiun":
                            {
                                _SavingThrow.Constitution = Func_Skill_Char(variable);
                            }
                            break;
                        case "_Intelligens":
                            {
                                _Chara._Abillities.Arcana = Func_Skill_Char(variable);
                                _Chara._Abillities.History = Func_Skill_Char(variable);
                                _Chara._Abillities.Investigation = Func_Skill_Char(variable);
                                _Chara._Abillities.Nature = Func_Skill_Char(variable);
                                _Chara._Abillities.Religion = Func_Skill_Char(variable);
                                _SavingThrow.Intelligence = Func_Skill_Char(variable);
                            }
                            break;
                        case "_Wise":
                            {
                                _Chara._Abillities.AnimalHandling = Func_Skill_Char(variable);
                                _Chara._Abillities.Insight = Func_Skill_Char(variable);
                                _Chara._Abillities.Medicine = Func_Skill_Char(variable);
                                _Chara._Abillities.Perception = Func_Skill_Char(variable);
                                _Chara._Abillities.Survival = Func_Skill_Char(variable);
                                _SavingThrow.Wisdom = Func_Skill_Char(variable);
                            }
                            break;
                        case "_Charisma":
                            {
                                _Chara._Abillities.Deception = Func_Skill_Char(variable);
                                _Chara._Abillities.Intimidation = Func_Skill_Char(variable);
                                _Chara._Abillities.Performance = Func_Skill_Char(variable);
                                _Chara._Abillities.Persuasion = Func_Skill_Char(variable);
                                _SavingThrow.Charisma = Func_Skill_Char(variable);

                            }
                            break;
                        default:
                            break;
                    }



                    _CharStac.DataContext = new Chara(_Chara);
                    _SavingByClass.DataContext = new SavingThrow(_SavingThrow);

                }
            }

        }


        private void TextBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {

            int variable;
            string Text = null;
            var Box = (TextBox)sender;


            if (!String.IsNullOrEmpty(Box.Text))
            {
                if (int.TryParse(Box.Text, out int result))
                {
                    variable = result;
                }
                else if (int.TryParse(Box.Text.Substring(0, 2), out int res))
                {

                    variable = res;

                }
                else if (int.TryParse(Box.Text.Substring(0, 1), out int ress))
                {
                    variable = ress;
                }
                else
                {
                    variable = 0;
                }

                if (variable > 30 || variable < 0)
                {
                    variable = 0;
                }

                Text = Func_Skill(variable);
                Box.Text = Text;


                switch (Box.Name)
                {
                    case "_Strength":
                        {
                            _Chara._Abillities.Athletics = Func_Skill_Char(variable);
                            _SavingThrow.Strength = Func_Skill_Char(variable);

                        }
                        break;
                    case "_Dexterity":
                        {
                            _Chara._Abillities.Acrobatics = Func_Skill_Char(variable);
                            _Chara._Abillities.SleightofHand = Func_Skill_Char(variable);
                            _Chara._Abillities.Stealth = Func_Skill_Char(variable);
                            _SavingThrow.Dexterity = Func_Skill_Char(variable);
                        }
                        break;
                    case "_Constitutiun":
                        {
                            _SavingThrow.Constitution = Func_Skill_Char(variable);
                        }
                        break;
                    case "_Intelligens":
                        {
                            _Chara._Abillities.Arcana = Func_Skill_Char(variable);
                            _Chara._Abillities.History = Func_Skill_Char(variable);
                            _Chara._Abillities.Investigation = Func_Skill_Char(variable);
                            _Chara._Abillities.Nature = Func_Skill_Char(variable);
                            _Chara._Abillities.Religion = Func_Skill_Char(variable);
                            _SavingThrow.Intelligence = Func_Skill_Char(variable);
                        }
                        break;
                    case "_Wise":
                        {
                            _Chara._Abillities.AnimalHandling = Func_Skill_Char(variable);
                            _Chara._Abillities.Insight = Func_Skill_Char(variable);
                            _Chara._Abillities.Medicine = Func_Skill_Char(variable);
                            _Chara._Abillities.Perception = Func_Skill_Char(variable);
                            _Chara._Abillities.Survival = Func_Skill_Char(variable);
                            _SavingThrow.Wisdom = Func_Skill_Char(variable);
                        }
                        break;
                    case "_Charisma":
                        {
                            _Chara._Abillities.Deception = Func_Skill_Char(variable);
                            _Chara._Abillities.Intimidation = Func_Skill_Char(variable);
                            _Chara._Abillities.Performance = Func_Skill_Char(variable);
                            _Chara._Abillities.Persuasion = Func_Skill_Char(variable);
                            _SavingThrow.Charisma = Func_Skill_Char(variable);

                        }
                        break;
                    default:
                        break;
                }



                _CharStac.DataContext = new Chara(_Chara);
                _SavingByClass.DataContext = new SavingThrow(_SavingThrow);

            }



        }


        private string Func_Skill(int variable)
        {
            int result = 0;
            string Text = null;
            switch (variable)
            {
                case 1:
                    {
                        result = -5;
                    }
                    break;
                case 2:
                    {
                        result = -4;
                    }
                    break;
                case 3:
                    {
                        result = -4;
                    }
                    break;
                case 4:
                    {
                        result = -3;
                    }
                    break;
                case 5:
                    {
                        result = -3;
                    }
                    break;
                case 6:
                    {
                        result = -2;
                    }
                    break;
                case 7:
                    {
                        result = -2;
                    }
                    break;
                case 8:
                    {
                        result = -1;
                    }
                    break;
                case 9:
                    {
                        result = -1;
                    }
                    break;
                case 10:
                    {
                        result = 0;
                    }
                    break;
                case 11:
                    {
                        result = 0;
                    }
                    break;
                case 12:
                    {
                        result = 1;
                    }
                    break;
                case 13:
                    {
                        result = 1;
                    }
                    break;
                case 14:
                    {
                        result = 2;
                    }
                    break;
                case 15:
                    {
                        result = 2;
                    }
                    break;
                case 16:
                    {
                        result = 3;
                    }
                    break;
                case 17:
                    {
                        result = 3;

                    }
                    break;
                case 18:
                    {
                        result = 4;
                    }
                    break;
                case 19:
                    {
                        result = 4;
                    }
                    break;
                case 20:
                    {
                        result = 5;
                    }
                    break;
                case 21:
                    {
                        result = 5;
                    }
                    break;
                case 22:
                    {
                        result = 6;
                    }
                    break;
                case 23:
                    {
                        result = 6;
                    }
                    break;
                case 24:
                    {
                        result = 7;

                    }
                    break;
                case 25:
                    {
                        result = 7;
                    }
                    break;
                case 26:
                    {
                        result = 8;
                    }
                    break;
                case 27:
                    {
                        result = 8;
                    }
                    break;
                case 28:
                    {
                        result = 9;
                    }
                    break;
                case 29:
                    {
                        result = 9;
                    }
                    break;
                case 30:
                    {
                        result = 10;
                    }
                    break;




                default:
                    {
                        result = 0;
                    }
                    break;
            }



            if (result < 0)
            {
                Text = $"{variable} = {result}";

            }
            else if (result >= 0)
            {
                Text = $"{variable} = +{result}";

            }







            return Text;

        }


        private string Func_Skill_Char(int variable)
        {
            int result = 0;
            string Text = null;
            switch (variable)
            {
                case 1:
                    {
                        result = -5;
                    }
                    break;
                case 2:
                    {
                        result = -4;
                    }
                    break;
                case 3:
                    {
                        result = -4;
                    }
                    break;
                case 4:
                    {
                        result = -3;
                    }
                    break;
                case 5:
                    {
                        result = -3;
                    }
                    break;
                case 6:
                    {
                        result = -2;
                    }
                    break;
                case 7:
                    {
                        result = -2;
                    }
                    break;
                case 8:
                    {
                        result = -1;
                    }
                    break;
                case 9:
                    {
                        result = -1;
                    }
                    break;
                case 10:
                    {
                        result = 0;
                    }
                    break;
                case 11:
                    {
                        result = 0;
                    }
                    break;
                case 12:
                    {
                        result = 1;
                    }
                    break;
                case 13:
                    {
                        result = 1;
                    }
                    break;
                case 14:
                    {
                        result = 2;
                    }
                    break;
                case 15:
                    {
                        result = 2;
                    }
                    break;
                case 16:
                    {
                        result = 3;
                    }
                    break;
                case 17:
                    {
                        result = 3;

                    }
                    break;
                case 18:
                    {
                        result = 4;
                    }
                    break;
                case 19:
                    {
                        result = 4;
                    }
                    break;
                case 20:
                    {
                        result = 5;
                    }
                    break;
                case 21:
                    {
                        result = 5;
                    }
                    break;
                case 22:
                    {
                        result = 6;
                    }
                    break;
                case 23:
                    {
                        result = 6;
                    }
                    break;
                case 24:
                    {
                        result = 7;

                    }
                    break;
                case 25:
                    {
                        result = 7;
                    }
                    break;
                case 26:
                    {
                        result = 8;
                    }
                    break;
                case 27:
                    {
                        result = 8;
                    }
                    break;
                case 28:
                    {
                        result = 9;
                    }
                    break;
                case 29:
                    {
                        result = 9;
                    }
                    break;
                case 30:
                    {
                        result = 10;
                    }
                    break;




                default:
                    {
                        result = 0;
                    }
                    break;
            }



            Text = $"{result}";







            return Text;

        }








        #endregion



        #region MagicDamage
        private void AddCast_Click(object sender, RoutedEventArgs e)
        {

            magicDamages.Add(new MagicDamage(_NamingText.Text, _BHZText.Text, _PowerSaveText.Text, _MagicBonusText.Text, new TextRange(_OpisText.Document.ContentStart, _OpisText.Document.ContentEnd).Text,_MageDistance.Text,MIMAGE));
            string item = $"Название: {_NamingText.Text}\nУрон Заклинания: {_BHZText.Text}\nСила спасброска: {_PowerSaveText.Text}\nБонус атаки: {_MagicBonusText.Text}\nДистанция: {_MageDistance.Text}\nОписание: {new TextRange(_OpisText.Document.ContentStart, _OpisText.Document.ContentEnd).Text}";
            _ListMageDamage.Items.Add(item);
            MIMAGE = null;
            MageImag.Source = null;
            MageImagTolT.Source = null;







        }

        private void DeleteMage_Click(object sender, RoutedEventArgs e)
        {
            if (_ListMageDamage.SelectedIndex != -1)
            {

                var index = _ListMageDamage.SelectedIndex;
                magicDamages.Remove(magicDamages[index]);
                _ListMageDamage.Items.Remove(_ListMageDamage.Items[index]);





            }
        }

        private void _ListMageDamage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            if (_ListMageDamage.SelectedIndex != -1)
            {

                
                var index = _ListMageDamage.SelectedIndex;
                _NamingText.Text = magicDamages[index].Naming;
                _BHZText.Text = magicDamages[index].BaseChar;
                _PowerSaveText.Text = magicDamages[index].SavePower;
                _MagicBonusText.Text = magicDamages[index].MagicDamageBonus;
                _OpisText.Document.Blocks.Clear();
                _OpisText.Document.Blocks.Add(new Paragraph(new Run(magicDamages[index].Opis)));
                _MageDistance.Text = magicDamages[index].distance;

                    MageImag.Source = magicDamages[index].PersonImage;
                    MageImagTolT.Source = magicDamages[index].PersonImage;



                //_OpisText.Text = magicDamages[index].Opis;


            }
           







        }

        private void SaveMageD_Click(object sender, RoutedEventArgs e)
        {
            if (_ListMageDamage.SelectedIndex != -1)
            {

                var index = _ListMageDamage.SelectedIndex;
                magicDamages[index].MagicDamageBonus = _MagicBonusText.Text;
                magicDamages[index].BaseChar = _BHZText.Text;
                magicDamages[index].Naming = _NamingText.Text;
                magicDamages[index].SavePower = _PowerSaveText.Text;
                magicDamages[index].distance = _MageDistance.Text;

                magicDamages[index].MageStringImage = MIMAGE;
               

                magicDamages[index].Opis = new TextRange(_OpisText.Document.ContentStart, _OpisText.Document.ContentEnd).Text;
                string item = $"Название: {_NamingText.Text}\nУрон Заклинания: {_BHZText.Text}\nСила спасброска: {_PowerSaveText.Text}\nБонус атаки: {_MagicBonusText.Text}\nДистанция: {_MageDistance.Text}\nОписание: {new TextRange(_OpisText.Document.ContentStart, _OpisText.Document.ContentEnd).Text}";

                _ListMageDamage.Items[index] = item;

                MIMAGE = null;
                MageImag.Source = null;
                MageImagTolT.Source = null;


            }
        }

        private void MImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (openFileDialog.ShowDialog() == true)
            {


                MIMAGE = PersonaBlock.ImgToStr(openFileDialog.FileName);
                MageImag.Source = PersonaBlock.BitmapToImageSourceS((Bitmap)PersonaBlock.StrToImg(MIMAGE));
                MageImag.Tag = MIMAGE;
                MageImagTolT.Source = PersonaBlock.BitmapToImageSourceS((Bitmap)PersonaBlock.StrToImg(MIMAGE));



            }
        }


        #endregion




        #region WeaponDamage






        private void _WeaponList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_WeaponList.SelectedIndex != -1)
            {

                var index = _WeaponList.SelectedIndex;
                WeapBonus.Text = weaponDamages[index].Bonus;
                WeapComboType.Text = weaponDamages[index].Type;
                WeapDescripto.Document.Blocks.Clear();
                WeapDescripto.Document.Blocks.Add(new Paragraph(new Run(weaponDamages[index].Descripto)));
               // WeapDescripto.Text = weaponDamages[index].Descripto;
                WeapDistance.Text = weaponDamages[index].Distance;
                WeapName.Text = weaponDamages[index].Naming;
                WeapComboDamage.SelectedIndex = weaponDamages[index].DamageIndex;



                WeapImag.Source = weaponDamages[index].PersonImage;
                WeapImagTolT.Source= weaponDamages[index].PersonImage;
            }
        }


        private void AddButtonWeap_Click(object sender, RoutedEventArgs e)
        {

            weaponDamages.Add(new WeaponDamage(WeapName.Text, WeapComboDamage.Text, WeapDistance.Text, new TextRange(WeapDescripto.Document.ContentStart, WeapDescripto.Document.ContentEnd).Text, WeapBonus.Text, WeapComboType.Text, WeapComboDamage.SelectedIndex,WIMAGE));
            string item = $"*------------*\nНазвание: {WeapName.Text}\nУрон: {WeapComboDamage.Text}\nБонус Атаки: {WeapBonus.Text}\nДистанция: {WeapDistance.Text}\nВид: {WeapComboType.Text}\nОписание: {new TextRange(WeapDescripto.Document.ContentStart, WeapDescripto.Document.ContentEnd).Text}";
            _WeaponList.Items.Add(item);
            WIMAGE = null;
            WeapImag.Source = null;
            WeapImagTolT.Source = null;
            

        }

        private void SaveButtonWeap_Click(object sender, RoutedEventArgs e)
        {
            if (_WeaponList.SelectedIndex != -1)
            {


                var index = _WeaponList.SelectedIndex;
                weaponDamages[index].Bonus = WeapBonus.Text;
                weaponDamages[index].Damage = WeapComboDamage.Text;
                weaponDamages[index].DamageIndex = WeapComboDamage.SelectedIndex;
                weaponDamages[index].Descripto = new TextRange(WeapDescripto.Document.ContentStart, WeapDescripto.Document.ContentEnd).Text;
                weaponDamages[index].Distance = WeapDistance.Text;
                weaponDamages[index].Type = WeapComboType.Text;
                weaponDamages[index].WeaponStringImage = WIMAGE;

                string item = $"*------------*\nНазвание: {WeapName.Text}\nУрон: {WeapComboDamage.Text}\nБонус Атаки: {WeapBonus.Text}\nДистанция: {WeapDistance.Text}\nВид: {WeapComboType.Text}\nОписание: {new TextRange(WeapDescripto.Document.ContentStart, WeapDescripto.Document.ContentEnd).Text}";
                _WeaponList.Items[index] = item;

                WIMAGE = null;
                WeapImag.Source = null;
                WeapImagTolT.Source = null;




            }




        }


        private void DeleteButtonWeap_Click(object sender, RoutedEventArgs e)
        {


            if (_WeaponList.SelectedIndex != -1)
            {

                var index = _WeaponList.SelectedIndex;
                weaponDamages.Remove(weaponDamages[index]);
                _WeaponList.Items.Remove(_WeaponList.Items[index]);


            }







        }







        private void WeapImag_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (openFileDialog.ShowDialog() == true)
            {


                WIMAGE = PersonaBlock.ImgToStr(openFileDialog.FileName);
                WeapImag.Source = PersonaBlock.BitmapToImageSourceS((Bitmap)PersonaBlock.StrToImg(WIMAGE));
                WeapImag.Tag = WIMAGE;
                WeapImagTolT.Source = PersonaBlock.BitmapToImageSourceS((Bitmap)PersonaBlock.StrToImg(WIMAGE));



            }



        }






        #endregion






        #region Loot
        private void _ListLootBag_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_ListLootBag.SelectedIndex != -1)
            {

                var index = _ListLootBag.SelectedIndex;

                LootCount.Text = lootBags[index].Count;

                LootDescr.Document.Blocks.Clear();
                LootDescr.Document.Blocks.Add(new Paragraph(new Run(lootBags[index].Description)));

                LootImag.Source = lootBags[index].PersonImage;
                LootImagTolT.Source = lootBags[index].PersonImage;

                //LootDescr.Text = lootBags[index].Description;


            }
        }


        private void AddButtonLoot_Click(object sender, RoutedEventArgs e)
        {

            lootBags.Add(new LootBag(new TextRange(LootDescr.Document.ContentStart, LootDescr.Document.ContentEnd).Text, LootCount.Text,LOOTIMAGE));
            string item = $"Количество: {LootCount.Text}\nОписание: {new TextRange(LootDescr.Document.ContentStart, LootDescr.Document.ContentEnd).Text}";
            _ListLootBag.Items.Add(item);
            LOOTIMAGE = null;
            LootImag.Source = null;
            LootImagTolT.Source = null;


        }

        private void SaveButtonLoot_Click(object sender, RoutedEventArgs e)
        {

            if (_ListLootBag.SelectedIndex != -1)
            {




                var index = _ListLootBag.SelectedIndex;
                lootBags[index].Count = LootCount.Text;
                lootBags[index].Description = new TextRange(LootDescr.Document.ContentStart, LootDescr.Document.ContentEnd).Text;
                lootBags[index].LootStringImage = LOOTIMAGE;

                string item = $"Количество: {LootCount.Text}\nОписание: {new TextRange(LootDescr.Document.ContentStart, LootDescr.Document.ContentEnd).Text}";
                _ListLootBag.Items[index] = item;

                LOOTIMAGE = null;
                LootImag.Source = null;
                LootImagTolT.Source = null;


            }

        }

        private void DeleteButtonLoot_Click(object sender, RoutedEventArgs e)
        {
            if (_ListLootBag.SelectedIndex != -1)
            {

                var index = _ListLootBag.SelectedIndex;
                lootBags.Remove(lootBags[index]);
                _ListLootBag.Items.Remove(_ListLootBag.Items[index]);


            }

        }

        private void LootImag_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (openFileDialog.ShowDialog() == true)
            {


                LOOTIMAGE = PersonaBlock.ImgToStr(openFileDialog.FileName);
                LootImag.Source = PersonaBlock.BitmapToImageSourceS((Bitmap)PersonaBlock.StrToImg(LOOTIMAGE));
                LootImag.Tag = LOOTIMAGE;
                LootImagTolT.Source = PersonaBlock.BitmapToImageSourceS((Bitmap)PersonaBlock.StrToImg(LOOTIMAGE));



            }
        }









        #endregion



        #region Conditions
        private void CondAdd_Click(object sender, RoutedEventArgs e)
        {
            conditionsLists.Add(new ConditionsList(TimeCond.Text, CondDesc.Text));
            string item = $"Эффект: {TimeCond.Text}\nДлительность: {CondDesc.Text}";
            CondList.Items.Add(item);
        }

        private void CondChange_Click(object sender, RoutedEventArgs e)
        {
            if (CondList.SelectedIndex!=-1)
            {
                int index = CondList.SelectedIndex;
                conditionsLists[index].Time = TimeCond.Text;
                conditionsLists[index].Effect = CondDesc.Text;
                string item = $"Эффект: {TimeCond.Text}\nДлительность: {CondDesc.Text}";
                CondList.Items[index] = item;



            }

        }

        private void CondDel_Click(object sender, RoutedEventArgs e)
        {
            if (CondList.SelectedIndex != -1)
            {
                var index = CondList.SelectedIndex;
                conditionsLists.Remove(conditionsLists[index]);
                CondList.Items.Remove(CondList.Items[index]);




            }
        }



        private void CondList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CondList.SelectedIndex != -1)
            {
                var index = CondList.SelectedIndex;
                TimeCond.Text = conditionsLists[index].Time;
                CondDesc.Text = conditionsLists[index].Effect;


            }


        }


        #endregion

      
    }
}
