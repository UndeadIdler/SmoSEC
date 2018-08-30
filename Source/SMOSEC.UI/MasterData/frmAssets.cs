using System;
using System.Data;
using Smobiler.Core.Controls;
using SMOSEC.UI.AssetsManager;
using Smobiler.Device;
using SMOSEC.DTOs.OutputDTO;

namespace SMOSEC.UI.MasterData
{

    /// <summary>
    /// �ʲ��б�����
    /// </summary>
    partial class frmAssets : Smobiler.Core.Controls.MobileForm
    {
        #region ����
        private AutofacConfig _autofacConfig = new AutofacConfig();//����������

        public string SelectAssId;  //��ǰѡ����ʲ�

        private string UserId;
        private string LocatinId;

        #endregion
        /// <summary>
        /// �����˼����رտͻ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAssets_KeyDown(object sender, KeyDownEventArgs e)
        {
            if (e.KeyCode == KeyCode.Back)
                Client.Exit();
        }

        /// <summary>
        /// ������
        /// </summary>
        public void Bind()
        {
            try
            {
                 LocatinId = "";
                if (Client.Session["Role"].ToString() != "ADMIN")
                {
                    var user = _autofacConfig.coreUserService.GetUserByID(UserId);
                    LocatinId = user.USER_LOCATIONID;
                }

                DataTable table = _autofacConfig.SettingService.GetAllAss(LocatinId);
                gridAssRows.Cells.Clear();
                table.Columns.Add("IsChecked");
                foreach (DataRow Row in table.Rows)
                {
                    if(Row["AssId"].ToString()==SelectAssId)
                    {
                        Row["IsChecked"] = true;
                    }
                    else
                    {
                        Row["IsChecked"] = false;
                    }
                }
                if (table.Rows.Count > 0)
                {
                    gridAssRows.DataSource = table;
                    gridAssRows.DataBind();
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        /// <summary>
        /// �����ʼ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAssets_Load(object sender, EventArgs e)
        {
            try
            {
                UserId = Client.Session["UserID"].ToString();
                Bind();
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }

        }

        /// <summary>
        /// �ֳ���������ɨ��ά�룬ɨ�赽����ʱ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void r2000Scanner1_BarcodeDataCaptured(object sender, Smobiler.Device.R2000BarcodeScanEventArgs e)
        {
            try
            {
                string barCode = e.Data;
                DataTable table = _autofacConfig.SettingService.GetAssetsBySN(barCode,LocatinId);
                gridAssRows.Cells.Clear();
                table.Columns.Add("IsChecked");
                foreach (DataRow Row in table.Rows)
                {
                    if (Row["AssId"].ToString() == SelectAssId)
                    {
                        Row["IsChecked"] = true;
                    }
                    else
                    {
                        Row["IsChecked"] = false;
                    }
                }
                if (table.Rows.Count > 0)
                {
                    gridAssRows.DataSource = table;
                    gridAssRows.DataBind();
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }

        }

        /// <summary>
        /// �ֳ���������ɨ��RFID��ɨ�赽RFID��Ϣʱ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void r2000Scanner1_RFIDDataCaptured(object sender, Smobiler.Device.R2000RFIDScanEventArgs e)
        {
            try
            {
                string RFID = e.Epc;
                DataTable table = _autofacConfig.SettingService.GetAssetsBySN(RFID,LocatinId);
                gridAssRows.Cells.Clear();
                table.Columns.Add("IsChecked");
                foreach (DataRow Row in table.Rows)
                {
                    if (Row["AssId"].ToString() == SelectAssId)
                    {
                        Row["IsChecked"] = true;
                    }
                    else
                    {
                        Row["IsChecked"] = false;
                    }
                }
                if (table.Rows.Count > 0)
                {
                    gridAssRows.DataSource = table;
                    gridAssRows.DataBind();
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        /// <summary>
        /// ���ActionButton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAssets_ActionButtonPress(object sender, ActionButtonPressEventArgs e)
        {

            try
            {
                switch (e.Index)
                {
                    case 0:     //�ʲ�����
                        try
                        {
                            if (Client.Session["Role"].ToString() == "SMOSECUser") throw new Exception("��ǰ�û�û��Ȩ�������ʲ�!");
                            frmAssetsCreate assetsCreate = new frmAssetsCreate();
                            Show(assetsCreate, (MobileForm sender1, object args) =>
                            {
                                if (assetsCreate.ShowResult == ShowResult.Yes)
                                {
                                    Bind();
                                }

                            }
                                );
                        }
                        catch (Exception ex)
                        {
                            Toast(ex.Message);
                        }
                        break;
                    case 1:
                        //�ʲ�����
                        try
                        {
                            if (Client.Session["Role"].ToString() == "SMOSECUser") throw new Exception("��ǰ�û�û��Ȩ�������ʲ�!");
                            if (string.IsNullOrEmpty(SelectAssId))
                            {
                                throw new Exception("����ѡ���ʲ�.");
                            }
                            var assets = _autofacConfig.SettingService.GetAssetsByID(SelectAssId);

                            frmAssetsCreate assetsCreate = new frmAssetsCreate
                            {
                                DatePickerBuy = { Value = assets.BuyDate },
                                DepId = assets.DepartmentId,
                                btnDep = { Text = assets.DepartmentName + "   > " },
                                DatePickerExpiry = { Value = assets.ExpiryDate },
                                ImgPicture = { ResourceID = assets.Image },
                                LocationId = assets.LocationId,
                                btnLocation = { Text = assets.LocationName },
                                ManagerId = assets.Manager,
                                txtManager = { Text = assets.ManagerName },
                                txtName = { Text = assets.Name },
                                txtNote = { Text = assets.Note },
                                txtPlace = { Text = assets.Place },
                                txtPrice = { Text = assets.Price.ToString()},
                                txtSpe = { Text = assets.Specification },
                                btnType = {Tag = assets.TypeId, Text = assets.TypeName },
                                txtUnit = { Text = assets.Unit},
                                txtVendor = { Text = assets.Vendor }
                            };

                            Show(assetsCreate, (MobileForm sender1, object args) =>
                                {
                                    if (assetsCreate.ShowResult == ShowResult.Yes)
                                    {
                                        Bind();
                                    }

                                }
                            );
                        }
                        catch (Exception ex)
                        {
                            Toast(ex.Message);
                        }
                        break;
                    case 2:
                        //�ʲ�����
                        frmCollarOrder frmCO = new frmCollarOrder();
                        Form.Show(frmCO);
                        break;
                    case 3:
                        //�ʲ�����
                        frmBorrowOrder frmBO = new frmBorrowOrder();
                        Form.Show(frmBO);
                        break;
                    case 4:
                        //ά�޵Ǽ�
                        frmRepairRowsSN frmR = new frmRepairRowsSN();
                        this.Form.Show(frmR);
                        break;
                    case 5:
                        //����
                        frmScrapRowsSN frmS = new frmScrapRowsSN();
                        this.Form.Show(frmS);
                        break;
                    case 6:
                        //����
                        frmTransferRowsSN frmT = new frmTransferRowsSN();
                        this.Form.Show(frmT);
                        break;
                    case 7:
                        try
                        {
                            if (string.IsNullOrEmpty(SelectAssId))
                            {
                                throw new Exception("����ѡ���ʲ�.");
                            }
                            AssetsOutputDto outputDto = _autofacConfig.SettingService.GetAssetsByID(SelectAssId);
                            PosPrinterEntityCollection Commands = new PosPrinterEntityCollection();
                            Commands.Add(new PosPrinterProtocolEntity(PosPrinterProtocol.Initial));
                            Commands.Add(new PosPrinterProtocolEntity(PosPrinterProtocol.EnabledBarcode));
                            Commands.Add(new PosPrinterProtocolEntity(PosPrinterProtocol.AbsoluteLocation));
                            Commands.Add(new PosPrinterBarcodeEntity(PosBarcodeType.CODE128Height, "62"));
                            Commands.Add(new PosPrinterBarcodeEntity(PosBarcodeType.CODE128, outputDto.SN));
                            //Commands.Add(new PosPrinterBarcodeEntity(PosBarcodeType.CODE128, "E2000017320082231027BD"));
                            Commands.Add(new PosPrinterProtocolEntity(PosPrinterProtocol.DisabledBarcode));
                            Commands.Add(new PosPrinterContentEntity(System.Environment.NewLine));
                            Commands.Add(new PosPrinterProtocolEntity(PosPrinterProtocol.Cut));

                            posPrinter1.Print(Commands, (obj, args) =>
                            {
                                if (args.isError == true)
                                    this.Toast("Error: " + args.error);
                                else
                                    this.Toast("��ӡ�ɹ�");
                            });
                        }
                        catch (Exception ex)
                        {
                            Toast(ex.Message);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }

        }

        /// <summary>
        /// �ֻ���ά��ɨ�赽��ά����Ϣʱ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barcodeScanner1_BarcodeScanned(object sender, BarcodeResultArgs e)
        {
            try
            {
                string barCode = e.Value;
                DataTable table = _autofacConfig.SettingService.GetAssetsBySN(barCode,LocatinId);
                gridAssRows.Cells.Clear();
                table.Columns.Add("IsChecked");
                foreach (DataRow Row in table.Rows)
                {
                    if (Row["AssId"].ToString() == SelectAssId)
                    {
                        Row["IsChecked"] = true;
                    }
                    else
                    {
                        Row["IsChecked"] = false;
                    }
                }
                if (table.Rows.Count > 0)
                {
                    gridAssRows.DataSource = table;
                    gridAssRows.DataBind();
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }
        /// <summary>
        /// ����SN��������ģ��ƥ���ѯ�ʲ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFactor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable table = _autofacConfig.SettingService.QueryAssets(txtNote.Text, LocatinId);
                gridAssRows.Cells.Clear();
                table.Columns.Add("IsChecked");
                foreach (DataRow Row in table.Rows)
                {
                    if (Row["AssId"].ToString() == SelectAssId)
                    {
                        Row["IsChecked"] = true;
                    }
                    else
                    {
                        Row["IsChecked"] = false;
                    }
                }
                if (table.Rows.Count > 0)
                {
                    gridAssRows.DataSource = table;
                    gridAssRows.DataBind();
                }
            }

            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }
        /// <summary>
        /// �ֻ�ɨ���ά��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imageButton1_Press(object sender, EventArgs e)
        {
            try
            {
                barcodeScanner1.GetBarcode();
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }
    }
}