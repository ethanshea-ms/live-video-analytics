class EnvVariables:
    def __init__(self):
        from dotenv import set_key, get_key, find_dotenv
        envPath = find_dotenv(raise_error_if_not_found=True)

        self.azureSubsctiptionId = get_key(envPath, "SUBSCRIPTION_ID")
        self.resourceLocation = get_key(envPath, "RESOURCE_LOCATION")
        self.resourceGroupName = get_key(envPath, "RESOURCE_GROUP")
        self.acrServiceName = get_key(envPath, "ACR_SERVICE_NAME")
        self.acrServiceFullName = get_key(envPath, "ACR_SERVICE_FULL_NAME")
        self.iotHubServiceName = get_key(envPath, "IOT_HUB_SERVICE_NAME")
        self.iotDeviceId = get_key(envPath, "IOT_DEVICE_ID")
        self.mediaServiceName = get_key(envPath, "AMS_ACCOUNT")
        self.storageServiceName = get_key(envPath, "STORAGE_SERVICE_NAME")
        self.acrUserName = get_key(envPath, "CONTAINER_REGISTRY_USERNAME_myacr")
        self.acrPassword = get_key(envPath, "CONTAINER_REGISTRY_PASSWORD_myacr")
        self.containerImageName = get_key(envPath, "CONTAINER_IMAGE_NAME")
        self.aadTenantId = get_key(envPath, "AAD_TENANT_ID")
        self.aadServicePrincipalId = get_key(envPath, "AAD_SERVICE_PRINCIPAL_ID")
        self.aadServicePrincipalSecret = get_key(envPath, "AAD_SERVICE_PRINCIPAL_SECRET")
        self.iotHubConnString = get_key(envPath, "IOT_HUB_CONN_STRING")
        self.iotEdgeDeviceConnString = get_key(envPath, "IOT_EDGE_DEVICE_CONN_STRING")
