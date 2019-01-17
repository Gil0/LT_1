using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea_1
{
    class Sintactico
    {
        public Respuesta analizarSintaxis(string Codigo)
        {
            Lexico Analiza_Lexico = new Lexico();
            Respuesta respuesta = new Respuesta();
            Analiza_Lexico.Inicia();
            Analiza_Lexico.Analiza(Codigo);

            if (Analiza_Lexico.NoTokens > 0)
            {
                if (Analiza_Lexico.Lexema[0] == "Programa")
                {





                    if (Analiza_Lexico.Token[1] == "id")
                    {
                        if (Analiza_Lexico.Lexema[2] == "Inicio")
                        {
                            int valido = 3;
                            for (int i = valido; i < Analiza_Lexico.NoTokens - 1; i++)
                            {
                                if (Analiza_Lexico.Token[i] == "PalabraReservada" && Analiza_Lexico.Lexema[i] != "Programa" && Analiza_Lexico.Lexema[i] != "Inicio" && Analiza_Lexico.Lexema[i] != "Fin")
                                {
                                    switch (Analiza_Lexico.Lexema[i])
                                    {
                                        case "DibujarCara":

                                            if (Analiza_Lexico.Lexema[i + 1] == "(")
                                            {
                                                if (Analiza_Lexico.Token[i + 2] == "num")
                                                {
                                                    if (Analiza_Lexico.Lexema[i + 3] == ",")
                                                    {
                                                        if (Analiza_Lexico.Token[i + 4] == "num")
                                                        {
                                                            if (Analiza_Lexico.Lexema[i + 5] == ",")
                                                            {
                                                                if (Analiza_Lexico.Token[i + 6] == "num")
                                                                {
                                                                    if (Analiza_Lexico.Lexema[i + 7] == ",")
                                                                    {
                                                                        if (Analiza_Lexico.Token[i + 8] == "id")
                                                                        {
                                                                            if (Analiza_Lexico.Lexema[i + 9] == ",")
                                                                            {
                                                                                if (Analiza_Lexico.Token[i + 10] == "Modo")
                                                                                {
                                                                                    if (Analiza_Lexico.Lexema[i + 11] == ")")
                                                                                    {
                                                                                        i = i + 11;
                                                                                        if (i == Analiza_Lexico.NoTokens - 2)
                                                                                        {
                                                                                            respuesta.estado = true;
                                                                                            respuesta.Mensaje = "[●][Estado: Exito] \nNo se han encontrado Errores";
                                                                                            return respuesta;
                                                                                            //Console.Out.WriteLine("No se han encontrado Errores");
                                                                                        }
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        respuesta.estado = false;
                                                                                        respuesta.Mensaje = "[x][Estado : Error]\n" + "[Tipo : Sintactico] Error en:" + Analiza_Lexico.Lexema[i + 11] + " Linea:" + numeroLinea(Codigo, Analiza_Lexico.Lexema[i + 11]) + "\n[Descripcion]: Se esperaba el elemento )";
                                                                                        //respuesta.Mensaje = "Error en: " + Analiza_Lexico.Lexema[i + 11] + "\n" + "Error [Sintactico]: Se esperaba el elemento )";
                                                                                        //Console.Out.WriteLine("Error en: " + Analiza_Lexico.Lexema[i + 11]);
                                                                                        //Console.Out.WriteLine("Error [Sintactico]: Se esperaba el elemento )");
                                                                                        i = Analiza_Lexico.NoTokens - 2;
                                                                                        return respuesta;
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    respuesta.estado = false;
                                                                                    respuesta.Mensaje = "[x][Estado : Error]\n" + "[Tipo : Sintactico] Error en:" + Analiza_Lexico.Lexema[i + 10] + " Linea:" + numeroLinea(Codigo, Analiza_Lexico.Lexema[i + 10]) + "\n[Descripcion]: Se esperaba un Modo valido (triste, enojada, feliz, dormida, neutral)";
                                                                                    //respuesta.Mensaje = "Error en: " + Analiza_Lexico.Lexema[i + 10] + "\n" + "Error [Sintactico]: Modo no valido (triste, enojada, feliz, dormida, neutral)";
                                                                                    //Console.Out.WriteLine("Error en: " + Analiza_Lexico.Lexema[i + 10]);
                                                                                    //Console.Out.WriteLine("Error [Sintactico]: Modo no valido (triste, enojada, feliz, dormida, neutral)");
                                                                                    i = Analiza_Lexico.NoTokens - 2;
                                                                                    return respuesta;
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                respuesta.estado = false;
                                                                                respuesta.Mensaje = "[x][Estado : Error]\n" + "[Tipo : Sintactico] Error en:" + Analiza_Lexico.Lexema[i + 9] + " Linea:" + numeroLinea(Codigo, Analiza_Lexico.Lexema[i + 9]) + "\n[Descripcion]: Se esperaba el elemento ,";
                                                                                //respuesta.Mensaje = "Error en: " + Analiza_Lexico.Lexema[i + 9] + "\n" + "Error [Sintactico]: Se esperaba una ,";
                                                                                //Console.Out.WriteLine("Error en: " + Analiza_Lexico.Lexema[i + 9]);
                                                                                //Console.Out.WriteLine("Error [Sintactico]: Se esperaba una ,");
                                                                                i = Analiza_Lexico.NoTokens - 2;
                                                                                return respuesta;
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            respuesta.estado = false;
                                                                            respuesta.Mensaje = "[x][Estado : Error]\n" + "[Tipo : Sintactico] Error en:" + Analiza_Lexico.Lexema[i + 8] + " Linea:" + numeroLinea(Codigo, Analiza_Lexico.Lexema[i + 8]) + "\n[Descripcion]: Se esperaba un tipo de nombre valido";
                                                                            //respuesta.Mensaje = "Error en: " + Analiza_Lexico.Lexema[i + 8] + "\n" + "Error [Sintactico]: Se esperaba un nombre valido";
                                                                            //Console.Out.WriteLine("Error en: " + Analiza_Lexico.Lexema[i + 8]);
                                                                            //Console.Out.WriteLine("Error [Sintactico]: Se esperaba un nombre valido");
                                                                            i = Analiza_Lexico.NoTokens - 2;
                                                                            return respuesta;
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        respuesta.estado = false;
                                                                        respuesta.Mensaje = "[x][Estado : Error]\n" + "[Tipo : Sintactico] Error en:" + Analiza_Lexico.Lexema[i + 7] + " Linea:" + numeroLinea(Codigo, Analiza_Lexico.Lexema[i + 7]) + "\n[Descripcion]: Se esperaba el elemento ,";
                                                                        //respuesta.Mensaje = "Error en: " + Analiza_Lexico.Lexema[i + 7] + "\n" + "Error [Sintactico]: Se esperaba una ,";
                                                                        //Console.Out.WriteLine("Error en: " + Analiza_Lexico.Lexema[i + 7]);
                                                                        //Console.Out.WriteLine("Error [Sintactico]: Se esperaba una ,");
                                                                        i = Analiza_Lexico.NoTokens - 2;
                                                                        return respuesta;
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    respuesta.estado = false;
                                                                    respuesta.Mensaje = "[x][Estado : Error]\n" + "[Tipo : Sintactico] Error en:" + Analiza_Lexico.Lexema[i + 6] + " Linea:" + numeroLinea(Codigo, Analiza_Lexico.Lexema[i + 6]) + "\n[Descripcion]: Se esperaba un tipo numerico";
                                                                    //respuesta.Mensaje = "Error en: " + Analiza_Lexico.Lexema[i + 6] + "\n" + "Error [Sintactico]: Se esperaba un numero";
                                                                    //Console.Out.WriteLine("Error en: " + Analiza_Lexico.Lexema[i + 6]);
                                                                    //Console.Out.WriteLine("Error [Sintactico]: Se esperaba un numero");
                                                                    i = Analiza_Lexico.NoTokens - 2;
                                                                    return respuesta;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                respuesta.estado = false;
                                                                respuesta.Mensaje = "[x][Estado : Error]\n" + "[Tipo : Sintactico] Error en: " + Analiza_Lexico.Lexema[i + 5] + " Linea:" + numeroLinea(Codigo, Analiza_Lexico.Lexema[i + 5]) + "\n[Descripcion]: Se esperaba el elemento ,";
                                                                //respuesta.Mensaje = "Error en: " + Analiza_Lexico.Lexema[i + 5] + "\n" + "Error [Sintactico]: Se esperaba una ,";
                                                                //Console.Out.WriteLine("Error en: " + Analiza_Lexico.Lexema[i + 5]);
                                                                //Console.Out.WriteLine("Error [Sintactico]: Se esperaba una ,");
                                                                i = Analiza_Lexico.NoTokens - 2;
                                                                return respuesta;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            respuesta.estado = false;
                                                            respuesta.Mensaje = "[x][Estado : Error]\n" + "[Tipo : Sintactico] Error en: " + Analiza_Lexico.Lexema[i + 4] + " Linea: " + numeroLinea(Codigo, Analiza_Lexico.Lexema[i + 4]) + "\n[Descripcion]: Se esperaba un tipo numerico";
                                                            //respuesta.Mensaje = "Error en: " + Analiza_Lexico.Lexema[i + 4] + "\n" + "Error [Sintactico]: Se esperaba un numero";
                                                            //Console.Out.WriteLine("Error en: " + Analiza_Lexico.Lexema[i + 4]);
                                                            //Console.Out.WriteLine("Error [Sintactico]: Se esperaba un numero");
                                                            i = Analiza_Lexico.NoTokens - 2;
                                                            return respuesta;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        respuesta.estado = false;
                                                        respuesta.Mensaje = "[x][Estado : Error]\n" + "[Tipo : Sintactico] Error en: " + Analiza_Lexico.Lexema[i + 3] + " Linea: " + numeroLinea(Codigo, Analiza_Lexico.Lexema[i + 3]) + "\n[Descripcion]: Se esperaba el elemento ,";
                                                        //respuesta.Mensaje = "Error en: " + Analiza_Lexico.Lexema[i + 3] + "\n" + "Error [Sintactico]: Se esperaba una ,";
                                                        //Console.Out.WriteLine("Error en: " + Analiza_Lexico.Lexema[i + 3]);
                                                        //Console.Out.WriteLine("Error [Sintactico]: Se esperaba una ,");
                                                        i = Analiza_Lexico.NoTokens - 2;
                                                        return respuesta;
                                                    }
                                                }
                                                else
                                                {
                                                    respuesta.estado = false;
                                                    respuesta.Mensaje = "[x][Estado : Error]\n" + "[Tipo : Sintactico] Error en: " + Analiza_Lexico.Lexema[i + 2] + " Linea: " + numeroLinea(Codigo, Analiza_Lexico.Lexema[i + 2]) + "\n[Descripcion]: Se esperaba un tipo numerico";
                                                    //respuesta.Mensaje = "Error en: " + Analiza_Lexico.Lexema[i + 2] + "\n" + "Error [Sintactico]: Se esperaba un numero";
                                                    //Console.Out.WriteLine("Error en: " + Analiza_Lexico.Lexema[i + 2]);
                                                    //Console.Out.WriteLine("Error [Sintactico]: Se esperaba un numero");
                                                    i = Analiza_Lexico.NoTokens - 2;
                                                    return respuesta;
                                                }
                                            }
                                            else
                                            {
                                                respuesta.estado = false;
                                                respuesta.Mensaje = "[x][Estado : Error]\n" + "[Tipo : Sintactico] Error en:" + Analiza_Lexico.Lexema[i + 1] + " Linea:" + numeroLinea(Codigo, Analiza_Lexico.Lexema[i + 1]) + "\n[Descripcion]: Se esperaba el elemento (";
                                                //respuesta.Mensaje = "Error en: " + Analiza_Lexico.Lexema[i + 1] + "\n" + "Error [Sintactico]: Se esperaba el elemento (";
                                                //Console.Out.WriteLine("Error en: " + Analiza_Lexico.Lexema[i + 1]);
                                                //Console.Out.WriteLine("Error [Sintactico]: Se esperaba el elemento (");
                                                i = Analiza_Lexico.NoTokens - 2;
                                                return respuesta;
                                            }
                                            break;

                                        case "EliminarCara":
                                            //Console.Out.WriteLine("Selecciono EliminarCara");
                                            if (Analiza_Lexico.Lexema[i + 1] == "(")
                                            {
                                                if (Analiza_Lexico.Token[i + 2] == "id")
                                                {
                                                    if (Analiza_Lexico.Lexema[i + 3] == ")")
                                                    {
                                                        i = i + 3;
                                                        if (i == Analiza_Lexico.NoTokens - 2)
                                                        {
                                                            respuesta.estado = true;
                                                            respuesta.Mensaje = "[●][Estado: Exito] \nNo se han encontrado Errores";
                                                            return respuesta;
                                                            //Console.Out.WriteLine("No se han encontrado Errores");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        respuesta.estado = false;
                                                        respuesta.Mensaje = "[x][Estado : Error]\n" + "[Tipo : Sintactico] Error en: " + Analiza_Lexico.Lexema[i + 3] + " Linea: " + numeroLinea(Codigo, Analiza_Lexico.Lexema[i + 3]) + "\n[Descripcion]: Se esperaba el elemento )";
                                                        //Console.Out.WriteLine("Error en: " + Analiza_Lexico.Lexema[i + 3]);
                                                        //Console.Out.WriteLine("Error [Sintactico]: Se esperaba el elemento )");
                                                        i = Analiza_Lexico.NoTokens - 2;
                                                        return respuesta;
                                                    }
                                                }
                                                else
                                                {
                                                    respuesta.estado = false;
                                                    respuesta.Mensaje = "[x][Estado : Error]\n" + "[Tipo : Sintactico] Error en: " + Analiza_Lexico.Lexema[i + 2] + " Linea: " + numeroLinea(Codigo, Analiza_Lexico.Lexema[i + 2]) + "\n[Descripcion]: Se esperaba un tipo de nombre valido";
                                                    //respuesta.Mensaje = "Error en: " + Analiza_Lexico.Lexema[i + 2] + "\n" + "Error [Sintactico]: Se esperaba un nombre valido";
                                                    //Console.Out.WriteLine("Error en: " + Analiza_Lexico.Lexema[i + 2]);
                                                    //Console.Out.WriteLine("Error [Sintactico]: Se esperaba un nombre valido");
                                                    i = Analiza_Lexico.NoTokens - 2;
                                                    return respuesta;
                                                }
                                            }
                                            else
                                            {
                                                respuesta.estado = false;
                                                respuesta.Mensaje = "[x][Estado : Error]\n" + "[Tipo : Sintactico] Error en: " + Analiza_Lexico.Lexema[i + 1] + " Linea: " + numeroLinea(Codigo, Analiza_Lexico.Lexema[i + 1]) + "\n[Descripcion]: Se esperaba el elemento (";
                                                //respuesta.Mensaje = "Error en: " + Analiza_Lexico.Lexema[i + 1] + "\n" + "Error[Sintactico]: Se esperaba el elemento(";
                                                //Console.Out.WriteLine("Error en: " + Analiza_Lexico.Lexema[i + 1]);
                                                //Console.Out.WriteLine("Error [Sintactico]: Se esperaba el elemento (");
                                                i = Analiza_Lexico.NoTokens - 2;
                                                return respuesta;
                                            }
                                            break;
                                        case "Dormir":
                                            if (Analiza_Lexico.Lexema[i + 1] == "(")
                                            {
                                                if (Analiza_Lexico.Token[i + 2] == "num")
                                                {
                                                    if (Analiza_Lexico.Lexema[i + 3] == ")")
                                                    {
                                                        i = i + 3;
                                                        if (i == Analiza_Lexico.NoTokens - 2)
                                                        {
                                                            respuesta.estado = true;
                                                            respuesta.Mensaje = "[●][Estado: Exito] \nNo se han encontrado Errores";
                                                            return respuesta;
                                                            //Console.Out.WriteLine("No se han encontrado Errores");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        respuesta.estado = false;
                                                        respuesta.Mensaje = "[x][Estado : Error]\n" + "[Tipo : Sintactico] Error en: " + Analiza_Lexico.Lexema[i + 3] + " Linea: " + numeroLinea(Codigo, Analiza_Lexico.Lexema[i + 3]) + "\n[Descripcion]: Se esperaba el elemento )";
                                                        //respuesta.Mensaje = "Error en: " + Analiza_Lexico.Lexema[i + 3] + "\n" + "Error [Sintactico]: Se esperaba el elemento )";
                                                        //Console.Out.WriteLine("Error en: " + Analiza_Lexico.Lexema[i + 3]);
                                                        //Console.Out.WriteLine("Error [Sintactico]: Se esperaba el elemento )");
                                                        i = Analiza_Lexico.NoTokens - 2;
                                                        return respuesta;
                                                    }
                                                }
                                                else
                                                {
                                                    respuesta.estado = false;
                                                    respuesta.Mensaje = "[x][Estado : Error]\n" + "[Tipo : Sintactico] Error en:" + Analiza_Lexico.Lexema[i + 2] + " Linea:" + numeroLinea(Codigo, Analiza_Lexico.Lexema[i + 2]) + "\n[Descripcion]: Se esperaba un tipo numerico";
                                                    //respuesta.Mensaje = "Error en: " + Analiza_Lexico.Lexema[i + 2] + "\n" + "Error [Sintactico]: Se esperaba un numero";
                                                    //Console.Out.WriteLine("Error en: " + Analiza_Lexico.Lexema[i + 2]);
                                                    //Console.Out.WriteLine("Error [Sintactico]: Se esperaba un numero");
                                                    i = Analiza_Lexico.NoTokens - 2;
                                                    return respuesta;
                                                }
                                            }
                                            else
                                            {
                                                respuesta.estado = false;
                                                respuesta.Mensaje = "[x][Estado : Error]\n" + "[Tipo : Sintactico] Error en: " + Analiza_Lexico.Lexema[i + 1] + " Linea: " + numeroLinea(Codigo, Analiza_Lexico.Lexema[i + 1]) + "\n[Descripcion]: Se esperaba el elemento (";
                                                //respuesta.Mensaje = "Error en: " + Analiza_Lexico.Lexema[i + 1] + "\n" + "Error [Sintactico]: Se esperaba el elemento (";
                                                //Console.Out.WriteLine("Error en: " + Analiza_Lexico.Lexema[i + 1]);
                                                //Console.Out.WriteLine("Error [Sintactico]: Se esperaba el elemento (");
                                                i = Analiza_Lexico.NoTokens - 2;
                                                return respuesta;
                                            }
                                            break;
                                        case "CambiarModo":
                                            if (Analiza_Lexico.Lexema[i + 1] == "(")
                                            {
                                                if (Analiza_Lexico.Token[i + 2] == "id")
                                                {
                                                    if (Analiza_Lexico.Lexema[i + 3] == ",")
                                                    {
                                                        if (Analiza_Lexico.Token[i + 4] == "Modo")
                                                        {
                                                            if (Analiza_Lexico.Lexema[i + 5] == ")")
                                                            {
                                                                i = i + 5;
                                                                if (i == Analiza_Lexico.NoTokens - 2)
                                                                {
                                                                    respuesta.estado = true;
                                                                    respuesta.Mensaje = "[●][Estado: Exito] \nNo se han encontrado Errores";
                                                                    return respuesta;
                                                                    //Console.Out.WriteLine("No se han encontrado Errores");
                                                                }
                                                            }
                                                            else
                                                            {
                                                                respuesta.estado = false;
                                                                respuesta.Mensaje = "[x][Estado : Error]\n" + "[Tipo : Sintactico] Error en: " + Analiza_Lexico.Lexema[i + 5] + " Linea: " + numeroLinea(Codigo, Analiza_Lexico.Lexema[i + 5]) + "\n[Descripcion]: Se esperaba el elemento )";
                                                                //respuesta.Mensaje = "Error en: " + Analiza_Lexico.Lexema[i + 5] + "\n" + "Error [Sintactico]: Se esperaba el elemento )";
                                                                //Console.Out.WriteLine("Error en: " + Analiza_Lexico.Lexema[i + 5]);
                                                                //Console.Out.WriteLine("Error [Sintactico]: Se esperaba el elemento )");
                                                                i = Analiza_Lexico.NoTokens - 2;
                                                                return respuesta;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            respuesta.estado = false;
                                                            respuesta.Mensaje = "[x][Estado : Error]\n" + "[Tipo : Sintactico] Error en: " + Analiza_Lexico.Lexema[i + 4] + " Linea: " + numeroLinea(Codigo, Analiza_Lexico.Lexema[i + 4]) + "\n[Descripcion]: Se esperaba un tipo de nombre valido";
                                                            //respuesta.Mensaje = "Error en: " + Analiza_Lexico.Lexema[i + 4] + "\n" + "Error [Sintactico]: Se esperaba un nombre valido";
                                                            //Console.Out.WriteLine("Error en: " + Analiza_Lexico.Lexema[i + 4]);
                                                            //Console.Out.WriteLine("Error [Sintactico]: Se esperaba un nombre valido");
                                                            i = Analiza_Lexico.NoTokens - 2;
                                                            return respuesta;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        respuesta.estado = false;
                                                        respuesta.Mensaje = "[x][Estado : Error]\n" + "[Tipo : Sintactico] Error en: " + Analiza_Lexico.Lexema[i + 3] + " Linea: " + numeroLinea(Codigo, Analiza_Lexico.Lexema[i + 3]) + "\n[Descripcion]: Se esperaba el elemento ,";
                                                        //respuesta.Mensaje = "Error en: " + Analiza_Lexico.Lexema[i + 3] + "\n" + "Error [Sintactico]: Se esperaba una ,";
                                                        //Console.Out.WriteLine("Error en: " + Analiza_Lexico.Lexema[i + 3]);
                                                        //Console.Out.WriteLine("Error [Sintactico]: Se esperaba una ,");
                                                        i = Analiza_Lexico.NoTokens - 2;
                                                        return respuesta;
                                                    }
                                                }
                                                else
                                                {
                                                    respuesta.estado = false;
                                                    respuesta.Mensaje = "[x][Estado : Error]\n" + "[Tipo : Sintactico] Error en: " + Analiza_Lexico.Lexema[i + 2] + " Linea: " + numeroLinea(Codigo, Analiza_Lexico.Lexema[i + 2]) + "\n[Descripcion]: Se esperaba un tipo de nombre valido";
                                                    //respuesta.Mensaje = "Error en: " + Analiza_Lexico.Lexema[i + 2] + "\n" + "Error [Sintactico]: Se esperaba un nombre valido";
                                                    //Console.Out.WriteLine("Error en: " + Analiza_Lexico.Lexema[i + 2]);
                                                    //Console.Out.WriteLine("Error [Sintactico]: Se esperaba un nombre valido");
                                                    i = Analiza_Lexico.NoTokens - 2;
                                                    return respuesta;
                                                }
                                            }
                                            else
                                            {
                                                respuesta.estado = false;
                                                respuesta.Mensaje = "[x][Estado : Error]\n" + "[Tipo : Sintactico] Error en: " + Analiza_Lexico.Lexema[i + 1] + " Linea: " + numeroLinea(Codigo, Analiza_Lexico.Lexema[i + 1]) + "\n[Descripcion]: Se esperaba el elemento (";
                                                //respuesta.Mensaje = "Error en: " + Analiza_Lexico.Lexema[i + 1] + "\n" + "Error [Sintactico]: Se esperaba el elemento (";
                                                //Console.Out.WriteLine("Error en: " + Analiza_Lexico.Lexema[i + 1]);
                                                //Console.Out.WriteLine("Error [Sintactico]: Se esperaba el elemento (");
                                                i = Analiza_Lexico.NoTokens - 2;
                                                return respuesta;
                                            }
                                            break;
                                        default:
                                            Console.Out.WriteLine("Selecciono otro");
                                            break;
                                    }
                                }
                                else
                                {
                                    respuesta.estado = false;
                                    respuesta.Mensaje = "[x][Estado : Error]\n" + "[Tipo : Sintactico] Error en: " + Analiza_Lexico.Lexema[i] + " Linea: " + numeroLinea(Codigo, Analiza_Lexico.Lexema[i]) + "\n[Descripcion]: Instruccion incorrecta, se esperaba algun tipo de instruccion bien formada";
                                    //respuesta.Mensaje = "Error en: " + Analiza_Lexico.Lexema[i] + "\n" + "Error [Lexico]: Instruccion incorrecta, se esperaba algun tipo de instruccion bien formada";
                                    return respuesta;
                                    //Console.Out.WriteLine("Error en: " + Analiza_Lexico.Lexema[i]);
                                    //Console.Out.WriteLine("Error [Lexico]: Instruccion incorrecta, se esperaba algun tipo de instruccion bien formada");
                                }
                            }

                            //Fin for

                            if (Analiza_Lexico.Lexema[Analiza_Lexico.NoTokens - 1] == "Fin")
                            {
                                respuesta.estado = true;
                                respuesta.Mensaje = "[●][Estado: Exito] \nNo se han encontrado Errores";
                                return respuesta;
                            } /////************************************ Aqui Fin
                            else
                            {
                                respuesta.estado = false;
                                ///aqui te quedaste we, lo tienes pegao
                                respuesta.Mensaje = "[x][Estado : Error]\n" + "[Tipo : Sintactico] Error en: " + Analiza_Lexico.Lexema[Analiza_Lexico.NoTokens - 1] + " Linea: " + numeroLinea(Codigo, Analiza_Lexico.Lexema[Analiza_Lexico.NoTokens - 1]) + "\n[Descripcion]: Se esperaba la palabra reservada Fin al final del codigo";
                                //respuesta.Mensaje = "Error en: " + Analiza_Lexico.Lexema[Analiza_Lexico.NoTokens - 1] + "\n" + "Error [Lexico]: Se esperaba la palabra reservada Fin";
                                return respuesta;
                                //Console.Out.WriteLine("Error en: " + Analiza_Lexico.Lexema[Analiza_Lexico.NoTokens - 1]);
                                //Console.Out.WriteLine("Error [Lexico]: Se esperaba la palabra reservada Fin");
                            }

                        }
                        else
                        {
                            respuesta.estado = false;
                            respuesta.Mensaje = "[x][Estado : Error]\n" + "[Tipo : Sintactico] Error en: " + Analiza_Lexico.Lexema[2] + " Linea: " + numeroLinea(Codigo, Analiza_Lexico.Lexema[2]) + "\n[Descripcion]: Se esperaba la palabra reservada Inicio";
                            return respuesta;
                            //respuesta.Mensaje = "[x][Estado : Error]\n" + "[Tipo : Sintactico] Error en: " + Analiza_Lexico.Lexema[2] + " Se esperaba la palabra reservada Inicio despues del nombre del Programa";
                            //respuesta.Mensaje = "Error en: " + Analiza_Lexico.Lexema[2] + "\n" + "Error [Lexico]: Se esperaba la palabra reservada Inicio antes de Fin";                            
                            //Console.Out.WriteLine("Error en: " + Analiza_Lexico.Lexema[2]);
                            //Console.Out.WriteLine("Error [Lexico]: Se esperaba la palabra reservada Inicio");
                        }
                    }
                    else
                    {
                        respuesta.estado = false;
                        respuesta.Mensaje = "[x][Estado : Error]\n" + "[Tipo : Sintactico] Error en: " + Analiza_Lexico.Lexema[1] + " Linea: " + numeroLinea(Codigo, Analiza_Lexico.Lexema[1]) + "\n[Descripcion]: Hace falta un nombre valido despues de la palabra reservada Programa";
                        //respuesta.Mensaje = "Error en: " + Analiza_Lexico.Lexema[1] + "\n" + "Error [Lexico]: Hace falta un nombre valido antes de la palabra reservada Fin";
                        return respuesta;
                        //Console.Out.WriteLine("Error en: " + Analiza_Lexico.Lexema[1]);
                        //Console.Out.WriteLine("Error [Lexico]: Nombre no valido");
                    }

                }
                else
                {
                    respuesta.estado = false;
                    respuesta.Mensaje = "[x][Estado : Error]\n" + "[Tipo : Sintactico] Error en: " + Analiza_Lexico.Lexema[0] + " Linea: " + numeroLinea(Codigo, Analiza_Lexico.Lexema[0]) + "\n[Descripcion]: Se esperaba la palabra reservada Programa";
                    //respuesta.Mensaje = "Error en: " + Analiza_Lexico.Lexema[0] + "\n" + "Error [Lexico]: Se esperaba la palabra reservada Programa";
                    return respuesta;
                    // Console.Out.WriteLine("Error en: " + Analiza_Lexico.Lexema[0]);
                    // Console.Out.WriteLine("Error [Lexico]: Se esperaba la palabra reservada Programa");
                }




            }
            else
            {
                respuesta.estado = false;
                respuesta.Mensaje = "[●][Estado: Exito] \nNo se han encontrado Errores";
                //respuesta.Mensaje = "[•][Estado : Exito]\n" + "[Tipo : nulo] "  + "\n[Descripcion]: No hay nada que analizar";
                //respuesta.Mensaje = "No hay nada que analizar";
                return respuesta;
                //Console.Out.WriteLine("No hay nada que analizar");
            }
            respuesta.estado = false;
            respuesta.Mensaje = "[●][Estado: Exito] \nNo se han encontrado Errores";
            //respuesta.Mensaje = "[•][Estado : Exito]\n" + "[Tipo : nulo] " + "\n[Descripcion]: No hay nada que analizar";
            //respuesta.Mensaje = "No hay nada que analizar";
            return respuesta;
        }

        public int numeroLinea(string codigo, string lexema)
        {
            int nolinea = 1;
            string linea = "";
            string aux = "";
            if (lexema != null)
            {                
                for (int i = 0; i < codigo.Length; i++)
                {
                    if (codigo[i] == '\n')
                    {
                        if (linea.Contains(lexema))
                        {
                            return nolinea;
                        }
                        nolinea = nolinea + 1;
                    }
                    else
                    {
                        aux = codigo[i].ToString();
                        linea = linea + aux;
                        if (i == codigo.Length - 1)
                        {
                            //Console.Out.WriteLine(linea);
                            //if (linea.Contains(lexema))
                            //{                            
                                return nolinea;
                            //}
                        }
                    }
                }
                return nolinea;
            }
            return nolinea;
        }
    }
}
