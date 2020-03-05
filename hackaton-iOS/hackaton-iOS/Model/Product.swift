//
//  Product.swift
//  hackaton-iOS
//
//  Created by Zendji Mizoguchi on 04/03/20.
//  Copyright © 2020 Zendji Mizoguchi. All rights reserved.
//

import Foundation

struct Product: Codable {
    
    var name: String
    var shortDescription: String
    var imageUrl: String
    var value: String
    var sku: String
}
