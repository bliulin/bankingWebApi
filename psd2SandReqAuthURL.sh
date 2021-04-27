#!bin/bash

###################################################################################
#                             REQUEST URL TO ING AUTHORIZATION APP                #
###################################################################################
# This script calls the endpoint "oauth2/authorization-server-url" to request     #
# an authorization code for requesting customer access token. In this script      #
# we pass "payment-account:balance:view" and "payment-accounts:transactions:view" #
# scope tokens to consume AIS API. You must request an application access token   #
# to run this script. Please update the variables "accessToken" and "certPath".   #
###################################################################################


keyId="5ca1ab1e-c0ca-c01a-cafe-154deadbea75" # client_id as provided in the documentation
certPath="/certs/" # path of the downloaded certificates and keys
httpHost="https://api.sandbox.ing.com"

# httpMethod must be in lower code
httpMethod="get"
reqPath="/oauth2/authorization-server-url?scope=payment-accounts%3Abalances%3Aview%20payment-accounts%3Atransactions%3Aview&redirect_uri=https://www.example.com&country_code=NL"

# Digest value for an empty body
digest="SHA-256=47DEQpj8HBSa+/TImW+5JCeuQeRkm5NMpJWZG3hSuFU="


# Generated value of the application access token. Please note that the access token expires in 15 minutes
accessToken="eyJhbGciOiJkaXIiLCJlbmMiOiJBMjU2Q0JDLUhTNTEyIiwia2lkIjoidHN0LTRjOGI1Mzk3LTFhYjgtNDFhOC1hNTViLWE3MTk5MTJiODNkMiIsImN0eSI6IkpXVCJ9..tjhH-ySBn40f8XruZeqTIg.nXF1HpEe2Q4BsVpXcHTdhvZ-tWDgq0BvheDMh9bsZad3qU-CkEO7HJLIzjG1nRf6qPIVk5Tx9PHIzDLzCjos1bmJdYMN7WkCXr5qFQkl6bS1WQU5X26oLgi-KGeDZeRW_S8k9REUH6BBg6PfGwS8nwBWo66H6kKd7q9fHjuTNPO9IPqBpZdZWOYBjwMmwAxbuZNiBCbBX3dBWXkJNrlAjIE-EPitdt_qdift4vyiOVbmMx9GSpbkc3RSqx8NfuBPrtiwcKpIPVeWRRUrNiJITleV-x73P5kvzbtrECMgS_1wlPtZ3Eayum6iLS7Z3vfs3EuVMZKbeSzuIZ0Qs7bM97LOMSOQUyNd2IiSoSRrLGHop3syaomLwU0sh5F028jLmG2f3xI8Azf6bP0yqdWMpOQS_xoA9z9Xa4kiMwMRlDEGgnIj2nAXrTGjYHCH54fiMLCKEUQZTxFmKVectbP-BdEyhF9bJcVsDdUeAdxnhuh3yw6Mm4jSphyIr_-BlWec0RbpTvgkFOjmyKVpVKc4j3W8mjNqGHbh2aGEarcykbf4TNft4nQY0FGRnxI0yky_33MCaqK_u3EEx4MOhuTmaD2Qr8SipyPYL_I_cQKX0aKUe5MV_MDQEqVJFX7SEnKkwJxtkc11vMSC1LBG8alpyFK3nqEH9eFzkiLF6vb0yC1bmQSw9IqJWWw8UV4GlosiAiFzStS9Z_mwooEAlNpCOZVXcE_zHALQvHSP7jNCxzitMzntjznCPIUXdnV-nznQ88Fnrkev3Shvs68n_i6v66UJ55ntKXguU3Pmfs4J5HI7wgEE3Ghwo7VZDug495CxwEx03iThnm7PDpMEp9vCoYNUoh3bQvLPXBie56hUdv0AWPHbhFAQzfngMliWt_n1LzPcN_a9Sz3cs3OH_j6iAjhZxwzVZWCl9Vk_qkaqx2t97mq_cV5YhlXH3zmpArDrd2T1pzaBZRwi4daepfzFZxslyeP1RsMG6fg8dRDoUN5jG9YGdv93D3pXSb6oKgEHZqEx408FhVcR-WPgIKkzQx7dABNh9GS6oKxjv8JNe99mtbb_4uv2F2VqNW3YbgB1jcELMn_h94FnAUfLP5LDanyHPUL4FVMzz79ZvdX0gbMprd8rrViIQ-lSEFUTufh2ts6ZLGEK3ocuwcxJZa_1SITwQChYJnJyPcSj4Nl2Uh489SJ6hY1VpGonvX7RU3RhBvlWvbzWbKgx8NnxACrVfbxqH9Vi9wPaNhL37Hle5KZQzMYfXB_mlrAhVpAqdPZVs6ydChLqLF5B2w7S4L0fNbJAbQ6CJyd8K9_6P_2Dxwhy-Jw-vWvZFGsnIxOT9pE2gu_Hm2h9Xt4ARdNWLD0PuzVO-OD91NlsZBAvSL2nnk80f9dO12kckshxLB0TJGJIFYDZxKUh4NppwGOiNIsBR9q8AxpDDgFOIaTjN2x_IDgCRJfE8-OLPk5-1kDNfAhJTiHI2KR2gpORit8vmd_OPnVP52sBv2b9xq5Vz-egk7tY74o_wVX_Om7qLCcmqqXIHLGeh-6fFtQzuPZ9rUQTURo_3D6Ici3ysTshNZFlGq2-5ZGt3BAFeDC87sXOF6mXIZAN7y8et9bHRyN0eCnSIk6kJcRD2K1PjT4RuoJ1GAbBsTFlNWHl37eniYV1WXVfsmOA7hoMFUXpriFqrG3K_YyfOPeD-XFf0jbNjpN7R_WsTlTl81iTbpNCEQzOBmgjRsdtkAs2H0GlcWLRn3jj734Qn4_skiWdNpKuSK1p0Ljp72zQhBgvpfI-H2CJCAkr4gG_Ukz8BE60Ch4WaJjPvf_7aLwoEPk-V5rLm-GMEe7oBKfqp3iWKv7VMo1cOWMr4P7DhvrZhqACSOr72jYPuaGMhSzldRc9hgnqJGR9ccwr1sQcy9BIlauUriZBIRO43H0q3a44NzJl6nhic6Us91Ef2vJ3OqXvt5Dc8H4kTbBVGUvCRylerRKNS56RRNDjaZnhTK8xGEc8RIYHCcUXidHfZ9Wed_oxebY7n05ljiTwZGWHdATMjgfgcVK1q_d7pZ1aCzcsSOHGefOdenJNYB0JpB-UOG2gbtpaVrBSgTzxX02lhPLsKcZTALjvyOxXW-dcsP-Dm1pN41b1Zsf9uoDZqF4Juy0HD9CRuklKu6pNI--TUdQ2kZ-SDpyPUf99tVDkWrpHrcHYXPbkqyvS6m2d-llU7bXjkJPYir2mSew4Ws1cliSeOXR59qDNGq3-Cf0WauHJ3qIx7SregjOz_G27MWp5W_swaQBkjZbOxSKI--gLP1-KJoqfJsxY3s8gYTERbUGhc3fZaDM9T2nIOyV225HzY1jcvdErAA8mTyq9UuT592E-mFE6r5dko0ayEoNX2xBwyBcTDlwsEFMYp39cdI7VYDCUP0sjlwnDbwFeyVIr53yRc9kEvqovggAnGZrelQDSqLt5opCOAH3mwg.2lIbjbKTg1-4k-6gBtJ0lt7RlsKTMyhtkKl_nFHHpR4"

reqDate=$(LC_TIME=en_US.UTF-8 date -u "+%a, %d %b %Y %H:%M:%S GMT")

# signingString must be declared exactly as shown below in separate lines
signingString="(request-target): $httpMethod $reqPath
date: $reqDate
digest: $digest"

signature=`printf %s "$signingString" | openssl dgst -sha256 -sign "${certPath}example_eidas_client_signing.key" | openssl base64 -A`

# Curl request method must be in uppercase e.g "POST", "GET"
curl -i -X GET "${httpHost}${reqPath}" \
-H "Accept: application/json" \
-H "Content-Type: application/json" \
-H "Digest: ${digest}" \
-H "Date: ${reqDate}" \
-H "Authorization: Bearer ${accessToken}" \
-H "Signature: keyId=\"$keyId\",algorithm=\"rsa-sha256\",headers=\"(request-target) date digest\",signature=\"$signature\"" \
-d "${payload}" \
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