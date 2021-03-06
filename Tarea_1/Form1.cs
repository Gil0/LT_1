﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tarea_1;

namespace Tarea_1
{
    public partial class Form1 : Form
    {

        String rutaArchivo;
        String nombre;
        String nombreInterprete = "Interprete Mamalon";
        Sintactico sintaxis = new Sintactico();

        public Form1()
        {
            InitializeComponent();                       
        }

        private void botonAbrirArchivo_Click(object sender, EventArgs e)
        {
            Stream Flujo;
            OpenFileDialog DialogoAbrirArchivo = new OpenFileDialog();
            DialogoAbrirArchivo.Filter = "(*.lt1)|*.lt1";
            if (DialogoAbrirArchivo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {                               
                if ( (Flujo = DialogoAbrirArchivo.OpenFile() )!= null )
                {
                    rutaArchivo = DialogoAbrirArchivo.FileName;
                    nombre = DialogoAbrirArchivo.SafeFileName;                    
                    String textoArchivo = File.ReadAllText(rutaArchivo);                  
                    areaEditor.Text = textoArchivo;
                    Form1.ActiveForm.Text = nombre + " - " + nombreInterprete; 
                    Flujo.Close();
                }
                else
                {
                    areaErrores.Text = "Error abrir Archivo";
                }            
            }
            else
            {
                areaErrores.Text = "Error al abrir dialogo abrir (valgame la redundancia xd)";
            }
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {            
            if ( (areaEditor.Text).Length == 0)
            {
                areaErrores.Text = "No hay codigo que guardar";
            }
            else
            {                      
                if (File.Exists(rutaArchivo))
                {
                    File.WriteAllText(rutaArchivo, areaEditor.Text);
                    areaErrores.Text = nombre + " Guardado con Exito";
                }
                else
                {
                    SaveFileDialog dialogoGuardar = new SaveFileDialog();
                    dialogoGuardar.AddExtension = true;
                    dialogoGuardar.DefaultExt = ".lt1";
                    dialogoGuardar.Filter = "(*.lt1)|*.lt1";
                    if (dialogoGuardar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        rutaArchivo = dialogoGuardar.FileName;
                        //Inicio Codigo para sacar Nombre (Eliminar si se encuentra otra manera)
                        String[] partesNombre = rutaArchivo.Split('\\');
                        nombre = partesNombre[partesNombre.Length - 1];
                        //Fin Codigo para sacar Nombre (Eliminar si se encuentra otra manera)
                        Form1.ActiveForm.Text = nombre + " - " + nombreInterprete;
                        File.WriteAllText(rutaArchivo, areaEditor.Text);
                    }
                    else
                    {
                        areaErrores.Text = "";
                    }
                }                                                                                                             
            }
        }

        private void botonEjecutar_Click(object sender, EventArgs e)
        {
            Respuesta respuesta = new Respuesta();
      
            if ((areaEditor.Text).Length == 0)
            {
                respuesta.estado = false;
                respuesta.Mensaje = "[•][Estado : Exito]\n" + "[Tipo : nulo] " + "\n[Descripcion]: No hay nada que analizar";
                areaErrores.Text = respuesta.Mensaje;
                textBox1.Text = "hola";

            }
            else
            {                
                respuesta = sintaxis.analizarSintaxis(areaEditor.Text);
                areaErrores.Text = respuesta.Mensaje;
                int contador = 0;
                string nombre = "";
                for (int j = 0; j < respuesta.listacaras.Count; j++)
                {
                    contador = 0;
                    Carita c = respuesta.listacaras[j];
                    nombre = respuesta.listacaras[j].Nombre;
                    for (int n = 0; n < respuesta.listacaras.Count; n++)
                    {
                        if (nombre == respuesta.listacaras[n].Nombre)
                        {
                            contador++;
                        }
                    }
                    if (contador <= 1)
                    {
                        areaErrores.Text = respuesta.Mensaje;
                        Graphics g = panel1.CreateGraphics();
                        if (c.Modo == "feliz")
                        {

                            Pen p = new Pen(Color.Black);
                            SolidBrush s = new SolidBrush(Color.Red);
                            g.DrawEllipse(p, c.X, c.Y, c.Radio, c.Radio);
                            g.FillEllipse(s, c.X, c.Y, c.Radio, c.Radio);
                        }
                        if (c.Modo == "triste")
                        {
                            Pen p = new Pen(Color.Black);
                            SolidBrush s = new SolidBrush(Color.Blue);
                            g.DrawEllipse(p, c.X, c.Y, c.Radio, c.Radio);
                            g.FillEllipse(s, c.X, c.Y, c.Radio, c.Radio);
                        }
                        if (c.Modo == "enojada")
                        {
                            Pen p = new Pen(Color.Black);
                            SolidBrush s = new SolidBrush(Color.Yellow);
                            g.DrawEllipse(p, c.X, c.Y, c.Radio, c.Radio);
                            g.FillEllipse(s, c.X, c.Y, c.Radio, c.Radio);
                        }
                    }
                    else
                    {
                        areaErrores.Text = "[x][Estado : Error]\n" + "[Tipo : Semántico] Ya existe una carita con el nombre " + nombre;
                    }
                }
            }
        }
                          
    

        private void botonNuevoArchivo_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialogoGuardar = new SaveFileDialog();
            dialogoGuardar.AddExtension = true;
            dialogoGuardar.DefaultExt = ".lt1";
            dialogoGuardar.Filter = "(*.lt1)|*.lt1";
      
            
            if (dialogoGuardar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {                                   
                rutaArchivo = dialogoGuardar.FileName;
                //Inicio Codigo para sacar Nombre (Eliminar si se encuentra otra manera)
                String[] partesNombre = rutaArchivo.Split('\\');
                nombre = partesNombre[partesNombre.Length - 1];
                //Fin Codigo para sacar Nombre (Eliminar si se encuentra otra manera)
                Form1.ActiveForm.Text = nombre + " - " + nombreInterprete;
                areaEditor.Text = "";
                File.WriteAllText(rutaArchivo,areaEditor.Text);
               

            }
            else
            {
                areaErrores.Text = "No se abrio dialogo guardar";
            }

          
        }


        

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
