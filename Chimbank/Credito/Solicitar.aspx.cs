﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Chimbank
{
    public partial class AbonarCredito : System.Web.UI.Page
    {
        Conexion conexion = new Conexion();

        static Dictionary<string, double> interes = new Dictionary<string, double>() { { "12", 0.91 }, { "24",1.02}, {"32",1.13 } };
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdquirirCredito_Click(object sender, EventArgs e)
        {
            if (conexion.Transacciones().Length > 10)
            {
                if (Usuario.user.Credito < 0)
                {
                    lblError.Visible = true;
                    lblError.ForeColor = Color.Red;

                    lblError.Text = "Tiene activo un credito actualmente, vuelva cuando no este activo";

                }
                else
                {
                    if (double.TryParse(txtvalorCredito.Text, out _))
                    {
                        double nuevo_credito = double.Parse(txtvalorCredito.Text) + (double.Parse(txtvalorCredito.Text) * interes[ddlMeses.SelectedItem.Text]);

                        conexion.HacerCredito(nuevo_credito, double.Parse(txtvalorCredito.Text));

                        lblError.Visible = true;

                        lblError.ForeColor = Color.Green;

                        lblError.Text = "Credito exitoso";

                    }
                    else
                    {
                        lblError.Visible = true;
                        lblError.ForeColor = Color.Red;

                        lblError.Text = "Ingrese un valor valido";

                    }

                }
                

            }
            else
            {
                lblError.Visible = true;
                lblError.ForeColor = Color.Red;
                
                lblError.Text = "No posee con las transferencia necesarias para adquirir prestamo (min 10)";

            }

        }

    }
}