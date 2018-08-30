using System;
using Smobiler.Core.Controls;
using SMOSEC.CommLib;
using SMOSEC.DTOs.InputDTO;
using SMOSEC.DTOs.OutputDTO;
using SMOSEC.UI.Layout;

namespace SMOSEC.UI.MasterData
{
    /// <summary>
    /// �ʲ��޸�
    /// </summary>
    partial class frmAssetsDetailEdit : Smobiler.Core.Controls.MobileForm
    {
        #region ����
        public string UserId;  //�û����
//        public string TypeId; //���ͱ��
        public string LocationId;  //������
        public string ManagerId;  //����Ա���
        public string CurrentUserId;  //��ǰ�û����

        AutofacConfig _autofacConfig = new AutofacConfig();//����������

        public string DepId; //���ű��
        public string AssId;  //�ʲ����
        

        #endregion

        /// <summary>
        /// �޸��ʲ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Press(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(LocationId))
                {
                    throw new Exception("��ѡ������.");
                }
                decimal price;
                if (!decimal.TryParse(txtPrice.Text, out price))
                {
                    throw new Exception("��������ȷ�ĵ���.");
                }
                AssetsInputDto assetsInputDto = new AssetsInputDto
                {
                    AssId = txtAssID.Text,
                    BuyDate = DatePickerBuy.Value,
                    CreateUser = UserId,
                    CurrentUser = CurrentUserId,
                    DepartmentId = DepId,
                    Image = ImgPicture.ResourceID,
                    LocationId = LocationId,
                    Manager = ManagerId,
                    ModifyUser = UserId,
                    Name = txtName.Text,
                    Note = txtNote.Text,
                    Place = txtPlace.Text,
                    Price = price,
                    Specification = txtSpe.Text,
                    TypeId = btnType.Tag.ToString(),
                    Unit = txtUnit.Text,
                    Vendor = txtVendor.Text,
                    ExpiryDate = DatePickerExpiry.Value,
                    SN = txtSN.Text
                };
                if (String.IsNullOrEmpty(txtPrice.Text) == false)
                    assetsInputDto.Price = decimal.Parse(txtPrice.Text);
                ReturnInfo returnInfo = _autofacConfig.SettingService.UpdateAssets(assetsInputDto);
                if (returnInfo.IsSuccess)
                {
                    ShowResult = ShowResult.Yes;
                    Close();
                    Toast("�޸ĳɹ�.");
                }
                else
                {
                    Toast(returnInfo.ErrorInfo);
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        /// <summary>
        /// �۸�ı�ʱ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal price;
                if (decimal.TryParse(txtPrice.Text, out price) == false)
                {
                    throw new Exception("��������ȷ�Ľ�");
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }


        /// <summary>
        /// �ʲ�����ѡ��ʱ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnType_Press(object sender, EventArgs e)
        {
            try
            {
                frmAssTypeChooseLayout layout = new frmAssTypeChooseLayout { IsCreate = false, typeId = btnType.Tag.ToString() };
                ShowDialog(layout);

            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        /// <summary>
        /// ����ϴ�ͼƬʱ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PanelImg_Press(object sender, EventArgs e)
        {
            CamPicture.GetPhoto();
        }

        


        /// <summary>
        /// ��ȡ��ͼƬ���ݺ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CamPicture_ImageCaptured(object sender, BinaryResultArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(e.error))
                {
                    e.SaveFile(UserId + DateTime.Now.ToString("yyyyMMddHHmm") + ".png");
                    ImgPicture.ResourceID = UserId + DateTime.Now.ToString("yyyyMMddHHmm");
                    ImgPicture.Refresh();
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        /// <summary>
        /// ������
        /// </summary>
        private void Bind()
        {

            try
            {
                AssetsOutputDto outputDto = _autofacConfig.SettingService.GetAssetsByID(AssId);
                if (outputDto != null)
                {
                    txtAssID.Text = outputDto.AssId;
                    ImgPicture.ResourceID = outputDto.Image;
                    txtNote.Text = outputDto.Note;
                    DatePickerExpiry.Value = outputDto.ExpiryDate;
                    txtName.Text = outputDto.Name;
                    txtPrice.Text = outputDto.Price.ToString();
                    txtSpe.Text = outputDto.Specification;
                    txtNote.Text = outputDto.Note;
                    txtPlace.Text = outputDto.Place;
                    txtSN.Text = outputDto.SN;
                    txtUnit.Text = outputDto.Unit;
                    txtVendor.Text = outputDto.Vendor;
                    txtDepart.Text = outputDto.DepartmentName;
                    DepId = outputDto.DepartmentId;
                    btnType.Text = outputDto.TypeName;
                    btnType.Tag = outputDto.TypeId;
                    txtLocation.Text = outputDto.LocationName;
                    LocationId = outputDto.LocationId;
                    txtManager.Text = outputDto.ManagerName;
                    ManagerId = outputDto.Manager;
                }
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        /// <summary>
        /// �����˼�ʱ���رյ�ǰ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAssetsDetailEdit_KeyDown(object sender, KeyDownEventArgs e)
        {
            if (e.KeyCode == KeyCode.Back)
            {
                Close();

            }
            
        }

        /// <summary>
        /// �����ʼ��ʱ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAssetsDetailEdit_Load(object sender, EventArgs e)
        {
            try
            {
                Bind();
                UserId = Session["UserID"].ToString();
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        /// <summary>
        /// �ֻ�ɨ��ά�����SN
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void ImgBtnForAssId_Press(object sender, EventArgs e)
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

        /// <summary>
        /// �ֳ�������ɨ���ά�룬ɨ�赽��ά������ʱ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void r2000Scanner1_BarcodeDataCaptured(object sender, Smobiler.Device.R2000BarcodeScanEventArgs e)
        {
            try
            {
                string barCode = e.Data;
                txtSN.Text = barCode;
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        /// <summary>
        /// �ֳ�������ɨ��RFID��ɨ�赽RFIDʱ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void r2000Scanner1_RFIDDataCaptured(object sender, Smobiler.Device.R2000RFIDScanEventArgs e)
        {
            try
            {
                string RFID = e.Epc;
                txtSN.Text = RFID;
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }

        /// <summary>
        /// �ֻ�ɨ�赽��ά��ʱ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barcodeScanner1_BarcodeScanned(object sender, BarcodeResultArgs e)
        {
            try
            {
                string barCode = e.Value;
                txtSN.Text = barCode;
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }
    }
}