#!bin/bash

###################################################################################
#                             CALL AIS ACCOUNTS 					              #
###################################################################################
# This script calls the AIS API in sandbox and performs a post request to the-    #
# endpoint "v3/accounts" for account details. You must request customer access-   #
# token to call this script.													  #
# Please update the variables "accessToken" and "certPath".   					  #
###################################################################################


keyId="5ca1ab1e-c0ca-c01a-cafe-154deadbea75" # client_id as provided in the documentation
certPath="/certs/" # path of the downloaded certificates and keys
httpHost="https://api.sandbox.ing.com"

# httpMethod value must be in lower case
httpMethod="get"
reqPath="/v3/accounts"

# Digest value for an empty body
digest="SHA-256=47DEQpj8HBSa+/TImW+5JCeuQeRkm5NMpJWZG3hSuFU="

# Generated value of the customer access token. Please note that the customer access token expires in 15 minutes
caccessToken="eyJhbGciOiJkaXIiLCJlbmMiOiJBMjU2Q0JDLUhTNTEyIiwia2lkIjoidHN0LTRjOGI1Mzk3LTFhYjgtNDFhOC1hNTViLWE3MTk5MTJiODNkMiIsImN0eSI6IkpXVCJ9..yLTp1j_jSX6PiQisKLGycw.-92Gn4fpHdTU6sLfImkI078w7AFcJplrPDoeuqInbK2Bh2kyUp70nKDMX7IVE4Z5Tab_ZAuSu-vDFjB3nyYmiOBhr4-rxJfdHpRW7-LZ4OojyA6Fkm0YQBylQef3vO5g85nUA52mp33cHUi5PDdaHF0v9FxuEreyY_T0rkXmvG17vTUFP7KP3DZUtgdEKmpzlRZM3TwJ3Y8tETLMIcFOq6csJoMgdvk_b-FoDMVMhlFsyxelM8OKm-4SrMLaiNdTwPFMObMGYFBatC-4h5ZlfgtNTIh-HPsp0Atb8qlHV_enzO3ymTG5DC9ytJ6jFojfgGKxn5HNlXrQzQVo_I8kHojtqDdXzfyNEm3qRp3I83utgU6JjT8OuhbcfW7Zlj_2p6NK4LPzTcVRi_MYunzn_OaS8VIRwW6iTOw7Y6jYavQ5WgsmHUz9zChcUVlScrlQLs9iExvBxWWkAWsGj55fVDnOVx3_TLngK7BIMRP1cniSXjAtuknHuEFiOk7U5cWL9Woaf8Ed6mpq_GsxmfniZPdvuMwwr_gpYNuYI3TPA8Z0oyb4XC8E7k0gGY8njsrtKr1rLoN5pLeVKFOO4ybg8tAfb9Coet7c3ZxMByaLKzAX-y8PlgzYP-tEXpFRbNkPzHf4SkE0TqE-E7vVxQLo1wF17jyUFYVZ94LAvd_1p-CRYo_n0KFdB8lUqQKlkAzcO0Ej3w_3iifYpk_dUhxegtF9w-CHujwOXa-4F1mpB-yEZ_uDss1U-5HHgRoGnuFMgFQMCtqfmCydKeNj_1tjrtIBJQ0zVGkHt1O_S2YevRbpRNzKzQ78CK67C8TJRQKvEySAJH3ERWZtODhpnDnjYOo0TkMjIpVmbx_LdvtR2DywKCDYSxmSMnjG5eCJjk20DhI4aIgPqimT0irL3nGhNZJE9w9yza5CJeLD5GXy2kJS6f1hlM0iBWdf2zJ_DJ1im--pVnEiJAFmL8VaaDyI-MTLZGG6SW9vlmTSsbP8ohEJaIDVLeVlGaQZWBTpbaY5W06-H0FsDlYF7_5QeaIsL7X--6hX40Bh3pERtNU5i_i9OiQ_mT2N9rSrvpCDTuS_M0cvaSKW7ibc4GKVKyX6vULzZRdjG3pHUhAatIh8hX8P6WTa0Kh8uTS8DpUdqe1pj_4xC_ytT8rI2rniIJv7qdM1k03sfdiDTIecuwb3mR63zeeUxsUcZiudNbx1_y82jwxSD5f8XnI0WzzH_c7w3f0sRgF9kyHZ-Lq-iho0JBqogQk-8k6GBWXGsGR27hNMd-0cSOXHAYrLBMiHBICCnO0ro0t72dbuti5rtJanC30-ZLHZgRwm4h4D83_NaIVszwqVHT28AjtROCx4Fml4a8qAxKo1ykcpTfz91vvKk-zTUbd7nb17_mhHh-CxvwBAzfBac5SoWuBZz_9FORmIvb0mjsOH3msNaQ1U7LWksEI-e4wPXX_rPbvbUp2X9IEzaDdumsig9w5yUHeXZIk2PFa6_qxxi7NgG7Z6ZkCUMLQFFRbB6-1rQVTsdKY0zHthvo5ePtKthPuAJJLE_1hpYZglEoKZMUj4tZTAgv5--HXbUBrsSlXu-yHpy5caBHDQF8TnVmnzFjWnDJbzLoUPkdb3egFfgsqD4HV2S_WMghreAXM7uJsdOC5qZECh3mjfGqzJnFHtKvaAK8jbGQtroiaIkcOkEPhC96kTXKG45aNeIvKxmSkuF1y0ocm4N0koQUMoWzsNGO6zV6pGTPfLxVA69ZbdN3_LKWH1Guk69e_EppUYmorRuDxGoYovhZg7gtZ7xHLk9vTbVkMj05wuXM03ggpkTHW_qqomokMJOdWtp3cNJkVBxlDh3WWpY2qGeZ7fqkX0OAFdGhch87ESAb8TVdy6aTJ81ZXbQ27IkRFejh46mm_LGQR0qvQf1CXK0FNu2l09zte0vPPUvw9fiyNCtXmqJezPtUnx4MCaoiAjjVRZ6X0n-59ibkwxODdc2RTkFA532xh8p6c9kS-GjEGOluhlw8Eelyy7Cx3zhqvGni6Zc76wQz657w0ArKQdteFHNJx4uI1gt_REN7JscTyHeyn82vWwSlgg92X9HJ9Rm5Pb9GzUH1vFse4FLQwwA3FsfVlsp54PcGh3u4twqjKFRAPEkwPh0uMv_Nx4FTTm4zFcf0QRY8f9l-icExskSHYl6olX2OBVhCaYnbqyeeZ6LCOycfh_goe298490dBYZjh1IsSqMVNBrjdmHCig08cgZMAFX2t8luiYu16GddLM3G6woloY_glGp6mwGJIdhVK-b4eUL_BoSmR2AIIGpYH2pKhMaQP0aUGHz3kcpUanhQqnLaaHMUrKEYDtET8i8rlEKpqlQuGHC42hxWFZssXswDvNXmgiVRAAYfabSWmBLQqlyhZuDgsNgx1biaxacUK3iTvKHVpW9iBNNJ4gY1ZZcu6r_hsn053htrDp9-atHKf-rgZAxOpr-5weGxkEmamIi2P0h1t4eSfJCmnsYj2efinE48NSLnR50ju9J92lYT12GzyE4KrOydVj3Z2xSDanO-Ek8tpUhNkwX-i43fpQwLUEiVUpgXkGS_07dcLN_QbrqJyLr8vDEqNTMGdbRf0xjWVoy4vfcnpGvpf043-xG_kIpSg9xAG0CTmnoBymhEN7phB0HEjS1-sHjORAHzfYD-8zWR5B-iTV6aCVEquG9NExV25tl9vgBixu6ThsBm5XXJ7xqbYcS5BzZ4TgyELixa0iYoPEd5hrWJwKWSqVZAnz4Mw-g0rW8YOjYMfnX9SUXLn-TftS6Cu2qJ-9GroxXHRX1oODifenxOvUkTPQgFCbgoapAGlv8ogRhFBGRVHEQR0-cqmhfThmTC5zxeLeK3TJzegWDmhWOqWNYijmeoazLSuqmB4QM2fb4OYEFth5ChbbIMQ4kJ0cdsM.faGoPxr0-FBr-26snIRwD_nCbWDkvrHVyfwlgLm7UHg","refresh_token":"eyJhbGciOiJkaXIiLCJlbmMiOiJBMjU2Q0JDLUhTNTEyIiwia2lkIjoidHN0LWVjOGY3YjQyLTkzNDYtNDQ1Yi04ZjNkLTc2ODBlZmJmZDA1OSJ9..ZGRT0k8sbY100  5480    0  5409  100    71  12757    167 --:--:-- --:--:-- --:--:-- 12924ESizgaZi5XNNnRUs-U93sN2u6DyJLkHhMyaHHECeD8JpxyfZKEiJK3IKrOyB1LtwPMGhg4Fkk-RgMOIBK5xQiVxCmf50aVqSFeY-3Vqyc1EWZOrl_Sfa01cRksoWevwoLfgJ40XwHlaCeIlusN_27GvPrqnaAeEkp2aT_vBp42-BvrD7VzI7GkZVxkGmX-d6y0shxTHCeybd13NTjrjFWQ-zEfv2g0gxZP_Y8eMqfdS6cHmlOckPcrbPAlE9WFAUNz-xQ2ZGgCYs4Q_tJEw1lfIO31v0WNa_wUSEUWIzlmJWTUHYJFsb_8gBhPbO4wzJFBvH4rwW4XhATyPTyAc-srnKgl42wa63HLYEn79MZ5etztcLioevbpEERcQ7YTHUACJSVY2eRNKqA4LSDvMaSKi-vsZoSNVP5wGvnHVufuMJoKEEvgyagO3H0l9dM40S9tf2AVHSeV9TR6ojnN5pHL5gPqJU9754xkHhVlDuTx0wMAkUh92bMp8DX09lWFjnN0_TX095SSox29SlApvrUOB_rHAiz8orwG654xHqgUE-sHYzWX3WAFgl8hrZcMk-av4t3qdIK96Cew6YWiMJ8LvhQFsa9GwWRa4CLKP1gllmOr1W1bSni5kDFFv0lgfdp4m_TqDoSuWfRBen7f_el54G9JNK5vpsmA9bGkyj10IU4PUjLnc8vdaD0h3KTeYwwl0DGQn6up-vSferQzXGffigx937xx8HziLSAmWb8I7GY9Ges2Gfld459hulDy0Ka0-vbv-8SjGcZ73_NWrW1DhHJ9sh7VoeI2Xx2xrh7mrs7G10u_FAItXytffHMiJsfZI4FczyJdX6dvMQ6kCN8p7reprn6eZ6fmfZaXhcqbfWVm_fUEuMNn9oXqndg-xRLzt2DWPfHB7GaOJ8yXwVGFdKvBSGPC0f8FhwQ-H8kNm37PLPtj7RmmHH5dxcz5J2v5D06PVH6KW8EfyDE6OAlMSHoJbaOJklIZa0uTdli6C9MD4K8gNrJx_UiOJ46yC5N50XpEmqNCTt5OUWqw8dncRCcrdvg_endcfh3ncH7As5mBidniE892FNNEghY9BBO12YsAN3gH2JkAmqi2yc9eJgyOxuUS90phD03C8M-IFZWDFCswBjznY55VfqQ1LzhLCZOMYipGi9rtUQmlQKHrIHb89alm0gGRtJ6uKLAH3o-a65EpO5YtX0R2Foch5Nem7XXFtoa6q8pVOv1iqeS2xPEPAeu7taj0ol3DH7ooaJ7mV3X6qNKNnr_B8ZHH-CEh92pJODko1pzdQx132PtEbUS8Uro4pLczGNwPpokdAAV_IoG1V9XS8IWm_rTfJKUFbh57gMD3M6NAzM1bHZTL7oTbBQSuDHMnh35O2dneep6-p-tjiObo80BiF8HVk4o65Luh7Mcjyf3Q6MOlrE0Odo1Ffnxc8tyVTrVQN5jDrjhgaGzXlFOByjchPW0h5b5cCY9vRaZ8xA_O8nl_5J_7VetTxPcsaOYyPU434HrGnGLlTx02tCa7RByfnZLcBNTAAZMSSH3wzJczs8vaZkTaB3Zfeh0XTEAVHZ5ScZ1KfP-tPf8riVBkLgoHyZHsDpTjA2MtPcMVb4MOMKZTj0jUSlgPp-kCkyQfqF9JMw8sN6A3chxrnmHLDF4EtfkIkvaqDyAFo5telWXgVA1GpLquJqmgzqGOS47hQ0iqPhWxKBOckXgKdI5sBq1_7H20g62ql1NU1jSuCxvme9MGGps7zgDnlDo2TxP381pQfN6X7keTJ5xLRYgQbxYawMiTaoweknfQmshIUpk4oh79mNi2eE36S7FDLwLvXrhT8Ndjf9tGROyW-YpJ-WVEiIu5N08PXCtr9L8o5LudwdbVNgCaDDZr5-vEhEPbIFZl8c9c_O4uO26ch.JJWDpn9CUXMKaJodZFkpByzfA8PFdvcTn3KbgwuAhuo"

reqDate=$(LC_TIME=en_US.UTF-8 date -u "+%a, %d %b %Y %H:%M:%S GMT")

# signingString must be declared exactly as shown below in separate lines
signingString="(request-target): $httpMethod $reqPath
date: $reqDate
digest: $digest"

# signingString must be declared exactly as shown below in separate lines
signature=`printf %s "$signingString" | openssl dgst -sha256 -sign "${certPath}example_eidas_client_signing.key" | openssl base64 -A`

# Curl request method must be in uppercase e.g "POST", "GET"
curl -i -X GET "${httpHost}$reqPath" \
-H "Accept: application/json" \
-H "Content-Type: application/json" \
-H "Digest: ${digest}" \
-H "Date: ${reqDate}" \
-H "Authorization: Bearer ${caccessToken}" \
-H "Signature: keyId=\"$keyId\",algorithm=\"rsa-sha256\",headers=\"(request-target) date digest\",signature=\"$signature\"" \
--cert "${certPath}example_eidas_client_tls.cer" \
--key "${certPath}example_eidas_client_tls.key"


echo "Press 'q' to exit"
count=0
while : ; do
read -n 1 k <&1
if [[ $k = q ]] ; then
printf "\nQuitting from the program\n"
break
else
((count=$count+1))
printf "\nIterate for $count times\n"
echo "Press 'q' to exit"
fi
done

