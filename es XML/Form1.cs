using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace es_XML
{
    public partial class Form1 : Form
    {
        static string pathXML;
        static Thread thMain;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenXML_Click(object sender, EventArgs e)
        {
            //vado a impostare il  tracciato xml
            if (!IsValid)//controllo tracciato su tutti i textbox
                return;
            pathXML = "fatturaTest.xml";
            XmlTextWriter xmlWrt = new XmlTextWriter(pathXML, Encoding.UTF8);
            xmlWrt.WriteProcessingInstruction("xml", "version='1.0' encoding='UTF-8' ");
            xmlWrt.Formatting = Formatting.Indented;

            //intestazione
            xmlWrt.WriteStartElement("p:FatturaElettronica");
            xmlWrt.WriteAttributeString("xmlns:ds", "http://222.23.org/2000/09/xmldsig#");
            xmlWrt.WriteAttributeString("xmlns:p", "http://ivaservizi.agenziaentrate.gov.it/docs/xsd/fatture/v1.2");//
            xmlWrt.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");//
            xmlWrt.WriteAttributeString("verisone", "FPR12");//FPA per PA
            xmlWrt.WriteAttributeString("xsi:schemaLocation", "http://ivaservizi.agenziaentrate.gov.it/docs/xsd/fatture/v1.2 http://www.fatturapa.gov.it/export/fatturazione/sdi/fatturapa/v1.2/Schema_del_file_xml_FatturaPA_versione_1.2.xsd");

            //head
            xmlWrt.WriteStartElement("FatturaElettronicaHeader");
            xmlWrt.WriteStartElement("DatiTrasmissione");
            xmlWrt.WriteStartElement("IdTrasmittente");
            xmlWrt.WriteElementString("IdPaese", txtIdPaese.Text);
            xmlWrt.WriteElementString("IdCodice", txtIdCodice.Text);
            xmlWrt.WriteEndElement(); // ID Trasimittente
            xmlWrt.WriteElementString("ProgressoInvio", txtProgressivoInvio.Text);
            xmlWrt.WriteElementString("FormatoTrasmissione", txtFormatoTrasmissione.Text);
            xmlWrt.WriteElementString("CodiceDestinatario", txtCodiceDestinatario.Text);
            xmlWrt.WriteStartElement("CedentePrestatore");
            xmlWrt.WriteStartElement("DatiAnagrafici");
            xmlWrt.WriteStartElement("IdFiscaleIVA");
            xmlWrt.WriteElementString("IdPaese", txtIDPaeseIva.Text);
            xmlWrt.WriteElementString("IdCodice", txtIdCOdiceIVA.Text);
            xmlWrt.WriteStartElement("Anagrafica");
            xmlWrt.WriteEndElement(); // Anagrafica
            xmlWrt.WriteElementString("RegimeFiscale", txtRegimeFiscale.Text);
            xmlWrt.WriteEndElement(); // IdFiscaleIVA
            xmlWrt.WriteEndElement(); // DatiAnagrafici
            xmlWrt.WriteStartElement("Sede");
            xmlWrt.WriteElementString("Indirizzo", txtIndirizzo.Text);
            xmlWrt.WriteElementString("CAP", txtCap.Text);
            xmlWrt.WriteElementString("Comune", txtComune.Text);
            xmlWrt.WriteElementString("Nazione", txtNazione.Text);
            xmlWrt.WriteEndElement(); // Sede
            xmlWrt.WriteEndElement(); // CedentePrestatore
            xmlWrt.WriteStartElement("CessionarioCommittente");
            xmlWrt.WriteStartElement("Sede");
            xmlWrt.WriteElementString("Indirizzo", txtIndirizzoCessionarioCommittente.Text);
            xmlWrt.WriteElementString("CAP", txtCapCessionarioCommittente.Text);
            xmlWrt.WriteElementString("Comune", txtComuneCessionarioCommittente.Text);
            xmlWrt.WriteElementString("Nazione", txtNazioneCessionarioCommittente.Text);
            xmlWrt.WriteEndElement(); 
            xmlWrt.WriteEndElement(); 
            xmlWrt.WriteEndElement(); 
            xmlWrt.WriteEndElement();

           //body
            xmlWrt.WriteStartElement("FatturaElettronicaBody");
            xmlWrt.WriteStartElement("DatiGenerali");
            xmlWrt.WriteStartElement("DatiGeneraliDocumento");
            xmlWrt.WriteElementString("TipoDocumento", ""); 
            xmlWrt.WriteElementString("Divisa", txtDivisa.Text);
            xmlWrt.WriteElementString("Data", txtData.Text);
            xmlWrt.WriteElementString("Numero", txtNumero.Text);
            xmlWrt.WriteEndElement(); 
            xmlWrt.WriteStartElement("DatiBeniServizi");
            xmlWrt.WriteStartElement("DettaglioLinee");
            xmlWrt.WriteElementString("NumeroLinea", txtNumeroLinea.Text);
            xmlWrt.WriteElementString("Descrizione", txtDescrizione.Text);
            xmlWrt.WriteElementString("PrezzoUnitario", txtPrezzoUnitario.Text);
            xmlWrt.WriteElementString("PrezzoTotale", txtPrezzoTotale.Text);
            xmlWrt.WriteElementString("AliquotaIVA", txtAliquotaIVA.Text);
            xmlWrt.WriteEndElement(); 
            xmlWrt.WriteStartElement("DatiRiepilogo");
            xmlWrt.WriteElementString("AliquotaIVA", txtAliquotaIvaRiepilogo.Text);
            xmlWrt.WriteElementString("ImponibileImporto", txtImponibileImposta.Text);
            xmlWrt.WriteElementString("Imposta", txtImposta.Text);
            xmlWrt.WriteEndElement(); 
            xmlWrt.WriteEndElement(); 
            xmlWrt.WriteEndElement(); 
            xmlWrt.WriteEndElement(); 
            xmlWrt.Close();
            MessageBox.Show("TRACCIATO XML GENERATO CORRETTAMENTE!!!");
            Process.Start("explorer.exe","/select,"+pathXML);//apre esplora risorse cosi da aprire subito l xml
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        TextBox txt;
        String regex = "";
        private void txtControl(object sender, KeyEventArgs e)
        {
            txt = (TextBox)sender;
            switch(txt.Name)
            {
                case "txtIdPaese":
                    regex = @"^[AD|AE|AG|AI|AL|AM|AN|AO|AR|AS|AT|AU|AW|AZ|BA|BB|BD|BE|BF|BG|BH|BI|BJ|BM|BN|BO|BR|BS|BT|BW|BY|BZ|CA|CC|CD|CF|CG|CH|CI|CK|CL|CM|CN|CO|CR|CU|CV|CX|CY|CZ|DE|DJ|DK|DM|DO|DZ|EC|EE|EG|ER|ES|ET|FI|FJ|FK|FO|FR|GA|GB|GD|GE|GF|GH|GN|GP|GQ|GR|GS|GT|GU|GW|GY|HK|HN|HR|HT|HU|ID|IE|IL|IN|IQ|IR|IS|IT|JM|JO|JP|KE|KG|KH|KI|KM|KN|KP|KR|KW|KY|KZ|LA|LB|LC|LI|LK|LR|LS|LT|LU|LV|LY|MA|MC|MD|MG|MH|MK|ML|MM|MN|MO|MP|MQ|MR|MS|MT|MU|MV|MW|MX|MY|MZ!NA|NC|NE|NF|NG|NI|NL|NO|NP|NR|NZ|OM|PA|PE|PF|PG|PH|PK|PL|PM|PN|PR|PT|PW|PY|QA|RE|RO|RU|RW|SA|SB|SC|SD|SE|SG|SH|SI|SK|SL|SM|SN|SO|SR|ST|SU|SV|SY|SZ|TC|TD|TF|TG|TH|TJ|TK|TN|TM|TO|TP|TR|TT|TV|TW|TZ|UA|UG|UM|US|UY|UZ|VA|VC|VE|VG|VI|VN|VU|WF|WS|XZ|YE|YT|YU|ZA|ZM|ZR|ZW]{2}$";
                    break;
                case "txtIdCodice":
                    regex = "^[a-zA-Z0-9]*$";
                    break;
                case "txtProgressivoInvio":
                    regex = "^[a-zA-Z0-9]*$";
                    break;
                case "txtFormatoTrasmissione":
                    regex = "FP[A|R]{1}12";
                    break;
                case "txtCodiceDestinatario":
                    regex = "^[a-zA-Z0-9]*$";
                    break;
                case "txtIDPaeseIva":
                    regex = @"^[AD|AE|AG|AI|AL|AM|AN|AO|AR|AS|AT|AU|AW|AZ|BA|BB|BD|BE|BF|BG|BH|BI|BJ|BM|BN|BO|BR|BS|BT|BW|BY|BZ|CA|CC|CD|CF|CG|CH|CI|CK|CL|CM|CN|CO|CR|CU|CV|CX|CY|CZ|DE|DJ|DK|DM|DO|DZ|EC|EE|EG|ER|ES|ET|FI|FJ|FK|FO|FR|GA|GB|GD|GE|GF|GH|GN|GP|GQ|GR|GS|GT|GU|GW|GY|HK|HN|HR|HT|HU|ID|IE|IL|IN|IQ|IR|IS|IT|JM|JO|JP|KE|KG|KH|KI|KM|KN|KP|KR|KW|KY|KZ|LA|LB|LC|LI|LK|LR|LS|LT|LU|LV|LY|MA|MC|MD|MG|MH|MK|ML|MM|MN|MO|MP|MQ|MR|MS|MT|MU|MV|MW|MX|MY|MZ!NA|NC|NE|NF|NG|NI|NL|NO|NP|NR|NZ|OM|PA|PE|PF|PG|PH|PK|PL|PM|PN|PR|PT|PW|PY|QA|RE|RO|RU|RW|SA|SB|SC|SD|SE|SG|SH|SI|SK|SL|SM|SN|SO|SR|ST|SU|SV|SY|SZ|TC|TD|TF|TG|TH|TJ|TK|TN|TM|TO|TP|TR|TT|TV|TW|TZ|UA|UG|UM|US|UY|UZ|VA|VC|VE|VG|VI|VN|VU|WF|WS|XZ|YE|YT|YU|ZA|ZM|ZR|ZW]{2}$";
                    break;
                case "txtIdCOdiceIVA":
                    regex = "^[a-zA-Z0-9]*$";
                    break;
                case "txtRegimeFiscale":
                    regex = "RF[0-1]{1}[0-9]{1}$";
                    break;
                case "txtIndirizzo":
                    regex = "^[a-zA-Z0-9]*$";
                    break;
                case "txtComune":
                    regex = "^[a-zA-Z0-9]*$";
                    break;
                case "txtCap":
                    regex = @"^\d{5}[-\s]?(?:\d{4})?$";
                    break;
                case "txtNazione":
                    regex = @"\b[A-Z]{2}\b";
                    break;
                case "txtIndirizzoCessionarioCommittente":
                    regex = "^[a-zA-Z0-9]*$";
                    break;
                case "txtComuneCessionarioCommittente":
                    regex = "^[a-zA-Z0-9]*$";
                    break;
                case "txtCapCessionarioCommittente":
                    regex = @"^\d{5}[-\s]?(?:\d{4})?$";
                    break;
                case "txtNazioneCessionarioCommittente":
                    regex = @"\b[A-Z]{2}\b";
                    break;
                case "txtIVAPaeseFiscale":
                    regex = @"^[AD|AE|AG|AI|AL|AM|AN|AO|AR|AS|AT|AU|AW|AZ|BA|BB|BD|BE|BF|BG|BH|BI|BJ|BM|BN|BO|BR|BS|BT|BW|BY|BZ|CA|CC|CD|CF|CG|CH|CI|CK|CL|CM|CN|CO|CR|CU|CV|CX|CY|CZ|DE|DJ|DK|DM|DO|DZ|EC|EE|EG|ER|ES|ET|FI|FJ|FK|FO|FR|GA|GB|GD|GE|GF|GH|GN|GP|GQ|GR|GS|GT|GU|GW|GY|HK|HN|HR|HT|HU|ID|IE|IL|IN|IQ|IR|IS|IT|JM|JO|JP|KE|KG|KH|KI|KM|KN|KP|KR|KW|KY|KZ|LA|LB|LC|LI|LK|LR|LS|LT|LU|LV|LY|MA|MC|MD|MG|MH|MK|ML|MM|MN|MO|MP|MQ|MR|MS|MT|MU|MV|MW|MX|MY|MZ!NA|NC|NE|NF|NG|NI|NL|NO|NP|NR|NZ|OM|PA|PE|PF|PG|PH|PK|PL|PM|PN|PR|PT|PW|PY|QA|RE|RO|RU|RW|SA|SB|SC|SD|SE|SG|SH|SI|SK|SL|SM|SN|SO|SR|ST|SU|SV|SY|SZ|TC|TD|TF|TG|TH|TJ|TK|TN|TM|TO|TP|TR|TT|TV|TW|TZ|UA|UG|UM|US|UY|UZ|VA|VC|VE|VG|VI|VN|VU|WF|WS|XZ|YE|YT|YU|ZA|ZM|ZR|ZW]{2}$";
                    break;
                case "txtCodicePaeseFiscale":
                    regex = "^[a-zA-Z0-9]*$";
                    break;
                case "txtTipoDocumento":
                    regex = "TD[0-2]{1}[0-9]{1}$";
                    break;
                case "txtDivisa":
                    regex = "^[AED|AFN|ALL|AMD|ANG|AOA|ARS|AUD|AWG|AZN|BAM|BBD|BDT|BGN|BHD|BIF|BMD|BND|BOB|BOV|BRL|BSD|BTN|BWP|BYN|BZD|CAD|CDF|CHE|CHF|CHW|CLF|CLP|CNY|COP|COU|CRC|CUC|CUP|CVE|CZK|DJF|DKK|DOP|DZD|EGP|ERN|ETB|EUR|FJD|FKP|GBP|GEL|GHS|GIP|GMD|GNF|GTQ|GYD|HKD|HNL|HRK|HTG|HUF|IDR|ILS|INR|IQD|IRR|ISK|JMD|JOD|JPY|KES|KGS|KHR|KMF|KPW|KRW|KWD|KYD|KZT|LAK||LBP|LKR|LRD|LSL|LYD|MAD|MDL|MGA|MKD|MMK|MNT|MOP|MRO|MUR|MVR|MWK|MXN|MXV|MYR|MZN|NAD|NGN|NIO|NOK|NPR|NZD|OMR|PAB|PEN|PGK|PHP|PKR|PLN|PYG|QAR|RON|RSD|RUB|RWF|SAR|SBD|SCR|SDG|SEK|SGD|SHP|SLL|SOS|SRD|SSP|STD|SYP|SZL|THB|TJS|TMT|TND|TOP|TRY|TTD|TWD|TZS|UAH|UGX|USD|USN|USS|UYU|UZS|VEF|VND|VUV|WST|XAF|XAG|XAL|XAU|XBA|XBB|XBC|XBD|XCD|XCP|XDR|XFO|XFU|XOF|XPD|XPF|XPT|XTS|XXX|YER|ZAR|ZMW|ZWL]{3}$";
                    break;
                case "txtData":
                    regex = "[0-9]{4}-[0-9]{2}-[0-9]{2}$";
                    break;
                case "txtNumero":
                    regex = "^[a-zA-Z0-9]*$";
                    break;
                case "txtNumeroLinea":
                    regex = "^[0-9]+$";
                    break;
                case "txtDescrizione":
                    regex = "^[a-zA-Z0-9]*$";
                    break;
                case "txtPrezzoUnitario":
                    regex = @"^[0-9]*([.][0-9]{1,2})?$";
                    break;
                case "txtPrezzoTotale":
                    regex = @"^[0-9]*([.][0-9]{1,2})?$";
                    break;
                case "txtAliquotaIVA":
                    regex = @"^[0-9]*([.][0-9]{1,2})?$";
                    break;
                case "txtImposta":
                    regex = @"^[0-9]*([.][0-9]{1,2})?$";
                    break;
                case "txtImponibileImposta":
                    regex = @"^[0-9]*([.][0-9]{1,2})?$";
                    break;
                case "txtAliquotaIvaRiepilogo":
                    regex = @"^[0-9]*([.][0-9]{1,2})?$";
                    break;
            }
            thMain = new Thread(ControllaTXT);
            thMain.Start();
            
        }

        private void ControllaTXT()
        {
            this.Invoke(new EventHandler(ControlloRegex));
        }

        bool IsValid = false;
        private void ControlloRegex(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txt.Text, regex))
            {
                txt.BackColor = Color.LightGreen;
                IsValid = true;
                if (txtRegimeFiscale.Text == "RF00" || txtTipoDocumento.Text=="TD28" || txtTipoDocumento.Text == "TD29" || txtTipoDocumento.Text == "TD00")
                {
                    txtRegimeFiscale.BackColor = Color.LightSalmon;
                    IsValid = false;
                }      
            }
            else
            {
                txt.BackColor = Color.LightSalmon;
                IsValid = false;
            }
        }

        TextBox txtInfo;
        private void ImpostaFatturaElettronica(object sender, EventArgs e)
        {
            txtInfo = (TextBox)sender;
            switch (txtInfo.Name)
            {
                case "txtIdPaese":
                    MessageBox.Show("INSERIRE NEL FORMATO da esempio: IT, ES, ecc.");
                    break;
                case "txtIdCodice":
                    MessageBox.Show("formato alfanumerico");
                    break;
                case "txtProgressivoInvio":
                    MessageBox.Show("formato alfanumerico");
                    break;
                case "txtFormatoTrasmissione":
                    MessageBox.Show("FPA12 oppure FPR12");
                    break;
                case "txtCodiceDestinatario":
                    MessageBox.Show("formato alfanumerico");
                    break;
                case "txtIDPaeseIva":
                    MessageBox.Show("INSERIRE NEL FORMATO da esempio: IT, ES, ecc.");
                    break;
                case "txtIdCOdiceIVA":
                    MessageBox.Show("formato alfanumerico");
                    break;
                case "txtRegimeFiscale":
                    MessageBox.Show("INSERIRE NEL FORMATO da esempio: RF01,RF02,RF19, ecc.");
                    break;
                case "txtIndirizzo":
                    MessageBox.Show("formato alfanumerico");
                    break;
                case "txtComune":
                    MessageBox.Show("formato alfanumerico");
                    break;
                case "txtCap":
                    MessageBox.Show("formato numerico");
                    break;
                case "txtNazione":
                    MessageBox.Show("INSERIRE NEL FORMATO da esempio: IT, ES, ecc.");
                    break;
                case "txtIndirizzoCessionarioCommittente":
                    MessageBox.Show("formato alfanumerico");
                    break;
                case "txtComuneCessionarioCommittente":
                    MessageBox.Show("formato alfanumerico");
                    break;
                case "txtCapCessionarioCommittente":
                    MessageBox.Show("formato numerico");
                    break;
                case "txtNazioneCessionarioCommittente":
                    MessageBox.Show("INSERIRE NEL FORMATO da esempio: IT, ES, ecc.");
                    break;
                case "txtIVAPaeseFiscale":
                    MessageBox.Show("INSERIRE NEL FORMATO da esempio: IT, ES, ecc.");
                    break;
                case "txtCodicePaeseFiscale":
                    MessageBox.Show("formato alfanumerico");
                    break;
                case "txtTipoDocumento":
                    MessageBox.Show("INSERIRE NEL FORMATO da TD01 a TD27");
                    break;
                case "txtDivisa":
                    MessageBox.Show("INSERIRE NEL FORMATO EUR, CHZ,CHF, ecc");
                    break;
                case "txtData":
                    MessageBox.Show("inserire nel formato YYYY-MM-GG");
                    break;
                case "txtNumero":
                    MessageBox.Show("formato alfanumerico");
                    break;
                case "txtNumeroLinea":
                    MessageBox.Show("formato numerico");
                    break;
                case "txtDescrizione":
                    MessageBox.Show("formato alfanumerico");
                    break;
                case "txtPrezzoUnitario":
                    MessageBox.Show("formato numero decimale es. prezzo: 11.20");
                    break;
                case "txtPrezzoTotale":
                    MessageBox.Show("formato numero decimale es. prezzo: 11.20");
                    break;
                case "txtAliquotaIVA":
                    MessageBox.Show("formato numero decimale es. percentuale: 11.2");
                    break;
                case "txtImposta":
                    MessageBox.Show("formato numero decimale es. prezzo: 11.20");
                    break;
                case "txtImponibileImposta":
                    MessageBox.Show("formato numero decimale es. prezzo: 11.20");
                    break;
                case "txtAliquotaIvaRiepilogo":
                    MessageBox.Show("formato numero decimale es. percentuale: 11.2");
                    break;
            }
        }
    }
}
